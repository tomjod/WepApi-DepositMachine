using Domain.Entities.BanknoteValidationModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBanknoteValidationModuleRepository
    {
        void CreateBanknoteValidationModule(BanknoteValidationModule banknoteValidationModule);

        Task<BanknoteValidationModule?> GetBanknoteValidationModuleAsync(BanknoteValidationModuleId Id);
    }
}
