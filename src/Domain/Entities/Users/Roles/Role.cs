using Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Users.Roles;

public sealed record Role
{
    public const string Admin = "Administrator"; 

    public const string Supervisor = "Supervisor";

    public const string Tesorero = "Tesorero";

    public const string Vigilante = "Vigilante";
}

