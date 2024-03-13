using Domain.Entities.Branches;
using Domain.Entities.Deposits;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Deposits
{
    public class DepositRepository : IDepositRepository
    {
        private readonly AppDbContext _dbContext;

        public DepositRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateDepositAsync(Deposit deposit) =>
            await _dbContext.Set<Deposit>().AddAsync(deposit);

        public async Task CreateDepositLineItemAsync(DepositLineItem depositLineItem) =>
            await _dbContext.Set<DepositLineItem>().AddAsync(depositLineItem);

        public async Task<Deposit?> GetDepositByBrachIdAsync(BranchId id) =>
            await _dbContext.Set<Deposit>()
                .FirstOrDefaultAsync(d => d.BranchId == id);

        public async Task<Deposit?> GetDepositByIdAsync(TransactionId id) =>
            await _dbContext.Set<Deposit>().FirstOrDefaultAsync(d => d.Id == id);

        public async Task<IEnumerable<Deposit?>> GetDepositsAsync() =>
            await _dbContext.Set<Deposit>().ToListAsync();
    }
}
