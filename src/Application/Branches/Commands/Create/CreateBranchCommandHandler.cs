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

    public CreateBranchCommandHandler(
        IBranchRepository repository, 
        IAddressRepository addressRepository, 
        IUnitOfWork unitOfWork,
        IApiKeyService apiKeyService,
        IApiKeyRepository apiKeyRepository)
    {
        _branchRepository = repository;
        _unitOfWork = unitOfWork;
        _addressRepository = addressRepository;
        _apiKeyRepository = apiKeyRepository;
        _apiKeyService = apiKeyService;
    }

    public async Task<Result<CreateBranchResponse>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Name))
        {
            return Result.Failure<CreateBranchResponse>(new Error(
                "Name.IsNull", "Name can't be null"));
        }
        
        if (request.Address == null)
        {
            return Result.Failure<CreateBranchResponse>(new Error(
                "Address.IsNull", "Address can't be null"));
        }

        if (string.IsNullOrEmpty(request.BranchCode))
        {
            return Result.Failure<CreateBranchResponse>(new Error(
                "BranchCode.IsNull", "BranchCode can't be null"));
        }

        var clientId = new ClientId(request.ClientId);
        DepositMachineId? depositMachineId = null;

        if (request.DepositMachineId != null)
        {
            depositMachineId = new DepositMachineId(
            (Guid)request.DepositMachineId);    
        }


        var branch = Branch.Create(
            clientId, 
            depositMachineId, 
            request.BranchCode, 
            request.PhoneNumber, 
            request.Manager, 
            request.Email);
            
        var address = Address.Create(
            branch.Value.Id,
            request.Address.Address1,
            request.Address.Address2,
            request.Address.City,
            request.Address.State,
            request.Address.Country,
            request.Address.PostalCode);
        
        var apikey =_apiKeyService.GenerateApiKey();
        var HashApiKey = _apiKeyService.HashApiKey(apikey);

        var apikeyEntity = ApiKey.Create(
            HashApiKey, 
            branch.Value.Id);

        _branchRepository.CreateBranch(branch.Value);

        _addressRepository.CreateAddress(address);

        _apiKeyRepository.CreateApiKey(apikeyEntity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var response = new CreateBranchResponse(branch.Value.Id.Value, apikey);

        return Result.Success(response);
    }
}
