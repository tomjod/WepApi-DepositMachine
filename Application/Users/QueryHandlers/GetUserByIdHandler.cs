using Application.Abstractions;
using Domain.User;
using MediatR;

namespace Application.Users.QueryHandlers;

public class GetUserByIdHandler : IRequestHandler<GetUserById, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public Task<User>? Handle(GetUserById request, CancellationToken cancellationToken)
    {
        if(request.userId == null)
        {
            throw new Exception("El id del usuario no puede ser null");
        }

        var user = _userRepository.GetUserByIdAsync(request.userId);

        if(user == null)
        {
            return null;
        }

        return user; 
    }
}
