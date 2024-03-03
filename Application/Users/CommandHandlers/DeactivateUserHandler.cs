
using Application.Abstractions;
using Domain.User;
using MediatR;

namespace Application.Users.CommandHandlers;

public class DeactivateUserHandler : IRequestHandler<DeactivateUser, User>
{
    private readonly IUserRepository _userRepository;

    public DeactivateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public Task<User> Handle(DeactivateUser request, CancellationToken cancellationToken)
    {
        if(request.userId == null)
        {
            throw new Exception("El id del usuario no puede ser null");
        }
        var user = _userRepository.GetUserByIdAsync(request.userId).Result;

        user.Deactivate();
        
        return _userRepository.DeactivateUserAsync(user);
    }
}