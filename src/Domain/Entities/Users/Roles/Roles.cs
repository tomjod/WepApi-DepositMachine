using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Users.Roles
{
    public class Roles : IdentityRole<UserId>
    {
        public UserId Id 
        { 
          get => base.Id; // base.Id;
          private set => base.Id = value;
        }
    }
}
