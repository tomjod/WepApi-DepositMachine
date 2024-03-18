using Application.Abstractions.Messaging;
using Domain.Entities.Seals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Seals.Commands.Create
{
    public sealed record CreateSealCommand(
        string SerialNumber, 
        Guid BagId,
        Guid DepositMachineId) : ICommand<SealId>
    {
    }
}
