using Domain.Entities.Users;

namespace Wep.API.Contracts.Users
{
    public sealed record UserRoleRequest(Guid Id, string roleName);

}
