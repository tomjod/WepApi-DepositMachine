using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserById;

    public sealed record GetUserByIdResponse(
        Guid id,
        string rut,
        string firstname,
        string lastname,
        string email);

    
    

