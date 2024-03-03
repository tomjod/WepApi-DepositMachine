using Application.Abstractions;
using Application.Clients.Commands;
using Domain.Client;

namespace Infrastucture.Repositories.Client;

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Client.Client> CreateClientAsync(Domain.Client.Client command)
    {
        await _context.Clients.AddAsync(command);
        await _context.SaveChangesAsync();
        return command;
    }
}
