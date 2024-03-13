using Application.Users.Commands.SetUserRole;
using Domain.Entities.Users;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharedKernel;
using System.Data;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    private readonly UserManager<User> _userManager;

    public UserRepository(AppDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IdentityResult> AddUserAsync(User ToCreate)
    {
        try
        {
            var result = await _userManager.CreateAsync(ToCreate);

            if (!result.Succeeded)
            {
                return result;
            }

            return result;
        }

        catch(Exception ex)
        {
            throw new Exception("No se pudo crear el usuario", ex);
        }
        
    }

    public async Task<User?> GetUserByIdAsync(UserId userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null) 
        {
            return null;
        }

        return user;
    }

    public async Task<ICollection<User>> GetAllUsersAsync() =>
        await _context.Users.ToListAsync();

    public void DeactivateUserAsync(User toDeactivate) =>
        _context.Users.AddAsync(toDeactivate);  

    public void SetUserRole(IdentityUserRole<UserId> userRole) => 
         _context.UserRoles.AddAsync(userRole);
    

    public async Task<bool> CheckIfRoleExistsAsync(string roleName) =>
        await _context.Roles.AnyAsync(r => r.Name == roleName);

    public async Task<bool> CheckIfUserAreInRoleAsync(UserId userId) =>
        await _context.UserRoles.AnyAsync(u => u.UserId == userId);



    public async Task<IdentityRole?> GetUserRoleAsync(UserId userId)
    {

        var roles = await (from user in _context.Users
                   join userRole in _context.UserRoles on user.Id equals userRole.UserId
                   join role in _context.Roles on userRole.RoleId equals role.Id
                   where user.Id == userId
                   select new { roleId = role.Id, roleName = role.Name }).FirstOrDefaultAsync();


        if (roles is null)
        {
            return null; 
        }

        var identityRole = new IdentityRole
        {
            Id = roles.roleId.ToString(),
            Name = roles.roleName,
        };

        return identityRole;
    }

    public async Task<IdentityRole<UserId>?> GetRoleByNameAsync(string roleName)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);

        return role;
    }

}
