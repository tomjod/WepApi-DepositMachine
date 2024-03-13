using MediatR;
using Application.Abstractions;
using Domain.Entities.Users;
using SharedKernel;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Application.Abstractions.Messaging;
using Domain.Repositories;

namespace Application.Users.Commands.CreateUser;

internal sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, UserId>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    // Handles the creation of a new user by taking in a CreateUser request and a cancellation token. 
    // Returns a Task that represents the asynchronous operation, which, upon completion, holds a User object.
    public async Task<Result<UserId>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Result<Email> emailResult = Email.Create(request.Email);
        Result<FirstName> firstNameResult = FirstName.Create(request.FirstName);
        Result<LastName> lastNameResult = LastName.Create(request.LastName);
        Result<RUN> userNameResult = RUN.Create(request.UserName);

        if (userNameResult.IsFailure)
        {
            return Result.Failure<UserId>(userNameResult.Error);
        }

        if (emailResult.IsFailure)
        {
            return Result.Failure<UserId>(emailResult.Error);
        }

        if (firstNameResult.IsFailure)
        {
            return Result.Failure<UserId>(firstNameResult.Error);
        }

        if (lastNameResult.IsFailure)
        {
            return Result.Failure<UserId>(lastNameResult.Error);
        }


        var user = User.Create(
            firstNameResult.Value,
            lastNameResult.Value,
            userNameResult.Value,
            emailResult.Value,
            request.Password); ;

        var result = await _userRepository.AddUserAsync(user);

        if (!result.Succeeded)
        {
            return null;
        }

        return user.Id;
    }
}
