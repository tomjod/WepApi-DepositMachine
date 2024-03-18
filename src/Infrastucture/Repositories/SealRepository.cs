using Domain.Entities.Seals;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{

    public class SealRepository : ISealRepository
    {
        private readonly AppDbContext _dbContext;

        public SealRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddSeal(Seal seal) =>
            _dbContext.Set<Seal>().Add(seal);

        public async Task<List<Seal>> GetAllSealsAsync(CancellationToken cancellationToken) =>
            await _dbContext
            .Set<Seal>()
            .ToListAsync();

        public async Task<Seal?> GetSealByIdAsync(SealId Id, CancellationToken cancellationToken) =>
            await _dbContext.Set<Seal>().FirstOrDefaultAsync(s => s.Id == Id);
    }
}
