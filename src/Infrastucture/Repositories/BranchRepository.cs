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
        private readonly AppDbContext _DbContext;

        public BranchRepository(AppDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public void CreateBranch(Branch branch) =>
            _DbContext.Set<Branch>().Add(branch);


        public async Task<IEnumerable<Branch>> GetAllBranchesAsync() =>
             await _DbContext.Set<Branch>().ToListAsync();
          

        public Task<Branch> GetBranchById(BranchId id)
        {
            throw new NotImplementedException();
        }
    }
}
