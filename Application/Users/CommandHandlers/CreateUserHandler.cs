using MediatR;
using Domain.User;
using Application.Users.Commands;
using Application.Abstractions;

namespace Application.Users.CommandHandlers;

public class CreateUserHandler : IRequestHandler<CreateUser, User>
{
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    // Handles the creation of a new user by taking in a CreateUser request and a cancellation token. 
    // Returns a Task that represents the asynchronous operation, which, upon completion, holds a User object.
    public async Task<User> Handle(CreateUser request, CancellationToken cancellationToken)
    {   
        var user = User.Create(
            request.FirtsName, 
            request.LastName, 
            request.UserName, 
            request.Email, 
            request.Password);
        
        await _userRepository.AddUserAsync(user);

        return user;
    }
}
