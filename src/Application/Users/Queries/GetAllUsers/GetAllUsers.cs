using Domain.Entities.Users;
using MediatR;

namespace Application.Users.Queries.GetAllUsers;

public class GetAllUsers : IRequest<ICollection<User>>
{

}
