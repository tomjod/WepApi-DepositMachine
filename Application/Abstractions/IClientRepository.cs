using Domain.Client;

namespace Application.Abstractions;

public interface IClientRepository
{
    public Task<Client> CreateClientAsync(Client client);
}
