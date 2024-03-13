using Application.Abstractions.Messaging;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.SetUserRole
{
    public class SetUserRoleCommand : ICommand<UserRoleResponse>
    {
        public  UserId Id { get; set; }

        public string RoleName { get; set; } = string.Empty;
    }
}
                     