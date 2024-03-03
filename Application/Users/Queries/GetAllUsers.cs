using Domain.User;
using MediatR;

namespace Application;

public class GetAllUsers : IRequest<ICollection<User>>
{
    
}
