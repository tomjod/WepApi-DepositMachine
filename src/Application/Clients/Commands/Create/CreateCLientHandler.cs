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

        if (!await _clientRepository.IsRutUniqueAsync(rutResult.Value))
        {
            return Result
                .Failure<ClientId>(
                DomainErrors.Client.RutAlreadyInUse);
        }

        var client = Client.Create(
            rutResult.Value,
            request.CompanyName,
            request.BusinessType,
            request.Representative);

         _clientRepository.CreateClient(client);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success(client.Id);
    }
}
