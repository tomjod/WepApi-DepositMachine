using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.SetUserRole;

public sealed record UserRoleResponse(
    Guid Id,
    string firstname,
    string lastname,
    string rut,
    string email, RoleResponse role);

public sealed record RoleResponse(Guid Id, string Name);