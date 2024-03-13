using Domain.Entities.Users;
using MediatR;
using Application.Abstractions.Messaging;

namespace Application.Users.Commands.DeactivateUser;

public sealed record DeactivateUserCommand(UserId userId) : ICommand;

