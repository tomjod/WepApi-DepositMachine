using Application.Abstractions;
using Application.Clients.Commands;
using Domain.Client;
using MediatR;

namespace Application.Clients.CommandHandlers;

public class CreateCLientHandler : IRequestHandler<CreateCLient, Client>
{
    private readonly IClientRepository _clientRepository;

    public CreateCLientHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<Client> Handle(CreateCLient request, CancellationToken cancellationToken)
    {
        if(request.VATnumber == null || request.CompanyName == null)
        {
            throw new Exception("Campos no pueden ser null");
        }
        
        var client = Client.Create(
            request.VATnumber, 
            request.CompanyName, 
            request.BusinessType, 
            request.Representative);

        await _clientRepository.CreateClientAsync(client);

        return client;
    }
}
