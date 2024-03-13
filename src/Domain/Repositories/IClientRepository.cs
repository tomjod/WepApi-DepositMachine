using Domain.Entities.Clients;
using Domain.ValueObjects;

namespace Domain.Repositories;

public interface IClientRepository
{
    void CreateClient(Client client, CancellationToken cancellationToken = default);
    Task<Client?> GetClientById(ClientId id, CancellationToken cancellationToken = default);

    Task<bool> IsRutUniqueAsync(RUT rut, CancellationToken cancellationToken = default);
}
