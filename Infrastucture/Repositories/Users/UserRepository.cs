using Application.Abstractions;
using Domain.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    private readonly UserManager<User> _userManager;

    public UserRepository(AppDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<User> AddUserAsync(User ToCreate)
    {
        try
        {
            var result = await _userManager.CreateAsync(ToCreate);
            return ToCreate;
        }

        catch(Exception ex)
        {
            throw new Exception("No se pudo crear el usuario", ex);
        }
        
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
