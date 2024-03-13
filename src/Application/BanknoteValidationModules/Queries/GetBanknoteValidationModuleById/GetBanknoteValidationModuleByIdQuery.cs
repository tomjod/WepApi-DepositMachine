using Application.Abstractions.Messaging;
using Domain.Entities.BanknoteValidationModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BanknoteValidationModules.Queries.GetBanknoteValidationModuleById
{
    public sealed record GetBanknoteValidationModuleByIdQuery(
        BanknoteValidationModuleId Id) : IQuery<BanknoteValidationModule>
    {
    }
}
