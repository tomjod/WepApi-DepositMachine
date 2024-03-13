using Application.Abstractions.Messaging;
using Domain.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clients.Queries
{
    public sealed record GetClientByIdQuery(Guid Id) : IQuery<Client>;

}
