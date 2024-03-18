using Application.Abstractions;
using Domain.Entities.Clients;
using MediatR;
using Application.Abstractions.Messaging;
using SharedKernel;
using Domain.Repositories;
using Domain.ValueObjects;
using Domain.Entities.Users;
using Domain.Errors;

namespace Application.Clients.Commands.Create;

public class CreateCLientHandler : ICommandHandler<CreateClientCommand, ClientId>
{
    private readonly IClientRepository _clientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCLientHandler(
        IClientRepository clientRepository, 
        IUnitOfWork unitOfWork)
    {
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ClientId>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        Result<RUT> rutResult = RUT.Create(request.Rut);

        if (rutResult.IsFailure)
        {
            return Result
                .Failure<ClientId>(rutResult.Error);
        }

        if (string.IsNullOrEmpty(request.CompanyName)) 
        { 
            return Result.Failure<ClientId>(new Error(
                "CompanyName.IsNull",
                "Company Name can't be null"));
        }

        if (!await _clientRepository.IsRutUniqueAsync(rutResult.Value))
        {
            return Result
                .Failure<ClientId>(
                DomainErrors.Client.RutAlreadyInUse);
        }

        var companyNameNormalized = request.CompanyName.ToUpper();
        var businessTypeNormalized = request.BusinessType.ToUpper();
        var representativeNormalized = request.Representative.ToUpper();

        var client = Client.Create(
            rutResult.Value,
            companyNameNormalized,
            businessTypeNormalized,
            representativeNormalized);

         _clientRepository.CreateClient(client);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success(client.Id);
    }
}
