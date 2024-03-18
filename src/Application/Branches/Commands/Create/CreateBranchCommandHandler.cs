using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Branches.Commands.Create;
using Domain;
using Domain.Entities.Addresses;
using Domain.Entities.ApiKeys;
using Domain.Entities.Branches;
using Domain.Entities.Clients;
using Domain.Entities.DepositMachines;
using Domain.Repositories;
using SharedKernel;

namespace Application;

public class CreateBranchCommandHandler : ICommandHandler<CreateBranchCommand, CreateBranchResponse>
{
    private readonly IBranchRepository _branchRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IApiKeyService _apiKeyService;
    private readonly IApiKeyRepository _apiKeyRepository;
    private readonly IClientRepository _clientRepository;

    public CreateBranchCommandHandler(
        IBranchRepository repository, 
        IAddressRepository addressRepository, 
        IUnitOfWork unitOfWork,
        IApiKeyService apiKeyService,
        IApiKeyRepository apiKeyRepository,
        IClientRepository clientRepository)
    {
        _branchRepository = repository;
        _unitOfWork = unitOfWork;
        _addressRepository = addressRepository;
        _apiKeyRepository = apiKeyRepository;
        _apiKeyService = apiKeyService;
        _clientRepository = clientRepository;
    }

    public async Task<Result<CreateBranchResponse>> Handle(
        CreateBranchCommand request, 
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Name))
        {
            return Result.Failure<CreateBranchResponse>(new Error(
                "Name.IsNull", 
                "Name can't be null"));
        }
        
        if (request.Address == null)
        {
            return Result.Failure<CreateBranchResponse>(new Error(
                "Address.IsNull", 
                "Address can't be null"));
        }

        if (string.IsNullOrEmpty(request.BranchCode))
        {
            return Result.Failure<CreateBranchResponse>(new Error(
                "BranchCode.IsNull", 
                "BranchCode can't be null"));
        }

        //Creo el clientId
        var clientId = new ClientId(request.ClientId);

        //Busco si el cliente existe
        var client = await _clientRepository.GetClientById(clientId);

        
        if (client is null) 
        {
            return Result.Failure<CreateBranchResponse>(new Error(
                "Client.NotFound",
                $"Client with Id {clientId.Value} is not found"));
        }

        DepositMachineId? depositMachineId = null;

        if (request.DepositMachineId != null)
        {
            depositMachineId = new DepositMachineId(
            (Guid)request.DepositMachineId);    
        }

        request.BranchCode = request.BranchCode.ToUpper();
        request.Email = request.Email.ToLower() ?? string.Empty;


        // Creo la instancia de la nueva sucursal
        var branch = Branch.Create(
            request.Name,
            clientId, 
            depositMachineId,
            request.BranchCode, 
            request.PhoneNumber, 
            request.Manager, 
            request.Email);

        // Creo la instancia de la direccion de la sucursal
        var address = Address.Create(
            branch.Value.Id,
            request.Address.Address1,
            request.Address.Address2,
            request.Address.City,
            request.Address.State,
            request.Address.Country,
            request.Address.PostalCode);
        
        // Genero la apiKey
        var apikey =_apiKeyService.GenerateApiKey();
        var HashApiKey = _apiKeyService.HashApiKey(apikey);

        // Creo la instancia de la ApiKey
        var apikeyEntity = ApiKey.Create(
            HashApiKey, 
            branch.Value.Id);

        // Creo en los  repositorios los cambios
        _branchRepository.CreateBranch(branch.Value);

        _addressRepository.CreateAddress(address);

        _apiKeyRepository.CreateApiKey(apikeyEntity);

        // Guardo los cambios a la base de datos
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Creo la respuesta
        var response = new CreateBranchResponse(branch.Value.Id.Value, apikey);

        return Result.Success(response);
    }
}
