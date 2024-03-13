using Domain.Repositories;
using Domain.Entities.Clients;
using Application.Clients.Commands;
using Microsoft.EntityFrameworkCore;
using Domain.ValueObjects;

namespace Infrastructure.Repositories.Clients;

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _dbContext;

    public ClientRepository(AppDbContext context)
    {
        _dbContext = context;
    }

    public void CreateClient(Client command, CancellationToken cancellationToken = default) =>
         _dbContext.Clients.Add(command);

    public async Task<Client?> GetClientById(ClientId id, CancellationToken cancellationToken = default) =>
        await _dbContext.Clients.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<bool> IsRutUniqueAsync(RUT rut, CancellationToken cancellationToken = default) =>
        !await _dbContext
        .Set<Client>()
        .AnyAsync(c => c.Rut == rut);

}
