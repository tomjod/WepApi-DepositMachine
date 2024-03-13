using Domain.Repositories;
using Domain.Entities.Users;
using MediatR;

namespace Application.Users.Queries.GetAllUsers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsers, ICollection<User>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public Task<ICollection<User>> Handle(GetAllUsers request, CancellationToken cancellationToken)
    {
        var users = _userRepository.GetAllUsersAsync();

        if (users == null)
        {
            throw new Exception("No se encontraron usuarios");
        }

        return users;
    }
}
