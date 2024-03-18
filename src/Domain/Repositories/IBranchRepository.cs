using Domain.Entities.Branches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBranchRepository
    {
        void CreateBranch(Branch branch);

        Task<IEnumerable<Branch>> GetAllBranchesAsync();

        Task<Branch?> GetBranchByIdAsync(BranchId id); 
    }
}
