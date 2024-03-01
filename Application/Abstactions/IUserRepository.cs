using Domain.User;

namespace Application.Abstactions;

public interface IUserRepository
{
    Task<ICollection<User>> GetAllUsersAsync();

    Task<User> GetUserByIdAsync(UserId userId);

    Task<User> AddUserAsync(User ToCreate);

    Task<User> DeactivateUserAsync(User toDeactivate);
}
