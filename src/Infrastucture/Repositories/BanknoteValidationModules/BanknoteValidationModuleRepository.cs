using Domain.Entities.BanknoteValidationModules;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.BanknoteValidationModules
{
    public class BanknoteValidationModuleRepository : IBanknoteValidationModuleRepository
    {
        private readonly AppDbContext _dbContext;

        public BanknoteValidationModuleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateBanknoteValidationModule(
            BanknoteValidationModule banknoteValidationModule) =>
            _dbContext.Add(banknoteValidationModule);

        public async Task<BanknoteValidationModule?> GetBanknoteValidationModuleAsync(
            BanknoteValidationModuleId Id,
            CancellationToken cancellationToken) =>
            await _dbContext
            .Set<BanknoteValidationModule>()
            .FirstOrDefaultAsync(b => b.Id == Id, cancellationToken);

        public async Task<bool> IsSerialUniqueAsync(
            string serialNumber, 
            CancellationToken cancellationToken = default) =>
            !await _dbContext
            .Set<BanknoteValidationModule>()
            .AnyAsync(b => b.SerialNumber == serialNumber, cancellationToken);
    }
}
