using Application.Abstractions.Messaging;
using Domain.Entities.DepositMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Machine.Commands
{
    public sealed record CreateDepositMachineCommand : ICommand<DepositMachineId>
    {
        public Guid BanknoteValidationModuleId { get; set; }
        public string SerialNumber { get; set; }
        public int ManufactureYear { get; set; } 
    }
}
