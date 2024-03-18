using Application.Abstractions.Messaging;
using Domain.Entities.DepositMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DepositMachines.Queries.GetDepositMachineById
{
    public sealed record GetDepositMachineByIdQuery(Guid Id) 
        : IQuery<DepositMachine>
    {
    }
}
