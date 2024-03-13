using Application.Abstractions.Messaging;
using Domain.Entities.Users;
using MediatR;
using System.Windows.Input;

namespace Application.Users.Queries.GetUserById;

public sealed record GetUserByIdQuery(UserId userId) : IQuery<GetUserByIdResponse>
{
}
