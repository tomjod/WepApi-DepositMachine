using Domain.Entities.Seals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ISealRepository
    {
        void AddSeal(Seal seal);

        Task<Seal?> GetSealByIdAsync(SealId Id, 
            CancellationToken cancellationToken);

        Task<List<Seal>> GetAllSealsAsync(CancellationToken cancellationToken);

    }
}
