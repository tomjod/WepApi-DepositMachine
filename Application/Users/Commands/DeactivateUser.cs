using Domain.User;
using MediatR;

namespace Application.Users.CommandHandlers;

public class DeactivateUser : IRequest<User>
{
        public UserId userId { get; set; }
}
