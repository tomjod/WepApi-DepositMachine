using Domain.User;
using MediatR;

namespace Application;

public class GetUserById : IRequest<User>
{
    public UserId userId { get; set; }
}
