using Application.Abstractions.Messaging;
using Domain.Entities.BanknoteValidationModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BanknoteValidationModules.Commands.Create
{
    public sealed record CreateBanknoteValidationModuleCommand : ICommand<BanknoteValidationModuleId>
    {
        public required string SerialNumber { get; set; }
        public required string Model {  get; set; }
        public int ManufactureYear { get; set; }
    }
}
