using Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using SharedKernel;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<ICollection<User>> GetAllUsersAsync();

    Task<User?> GetUserByIdAsync(UserId userId);

    Task<IdentityResult> AddUserAsync(User ToCreate);

    void DeactivateUserAsync(User toDeactivate);

    void SetUserRole(IdentityUserRole<UserId> userRole);

    Task<IdentityRole?> GetUserRoleAsync(UserId Id);

    Task<bool> CheckIfRoleExistsAsync(string roleName);

    Task<IdentityRole<UserId>?> GetRoleByNameAsync(string roleName);

    Task<bool> CheckIfUserAreInRoleAsync(UserId userId);

}
