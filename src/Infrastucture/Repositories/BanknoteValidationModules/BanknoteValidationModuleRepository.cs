using Domain.Entities.BanknoteValidationModules;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.BanknoteValidationModules
{
    public class BanknoteValidationModuleRepository : IBanknoteValidationModuleRepository
    {
        private readonly AppDbContext _DbContext;

        public BanknoteValidationModuleRepository(AppDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public void CreateBanknoteValidationModule(BanknoteValidationModule banknoteValidationModule) =>
            _DbContext.Add(banknoteValidationModule);

        public Task<BanknoteValidationModule?> GetBanknoteValidationModuleAsync(BanknoteValidationModuleId Id) =>
            _DbContext.Set<BanknoteValidationModule>().FirstOrDefaultAsync(b => b.Id == Id);
        
    }
}
