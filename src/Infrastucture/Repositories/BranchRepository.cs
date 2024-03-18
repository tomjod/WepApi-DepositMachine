using Domain.Entities.Branches;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly AppDbContext _dbContext;

        public BranchRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateBranch(Branch branch) =>
            _dbContext.Set<Branch>().Add(branch);


        public async Task<IEnumerable<Branch>> GetAllBranchesAsync() =>
             await _dbContext.Set<Branch>().ToListAsync();
          

        public async Task<Branch?> GetBranchByIdAsync(BranchId id) => 
            await _dbContext.Set<Branch>().FirstOrDefaultAsync(x => x.Id == id);
    }
}
