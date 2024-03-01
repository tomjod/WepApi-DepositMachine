using Application.Abstactions;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> AddUserAsync(User ToCreate)
    {
        _context.Users.Add(ToCreate);
        await _context.SaveChangesAsync();

        return ToCreate;
    }

    public async Task<ICollection<User>> GetAllUsersAsync()
    {
        var users = await _context.Users.ToListAsync();

        return users;
    }

    public async Task<User> GetUserByIdAsync(UserId userId)
    {
        return  await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<User> DeactivateUserAsync(User toDeactivate)
    {
        _context.Users.Add(toDeactivate);
        await _context.SaveChangesAsync();

        return toDeactivate;
    }
}
