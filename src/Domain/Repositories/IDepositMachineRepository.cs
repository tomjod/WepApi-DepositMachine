using Domain.Entities.DepositMachines;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IDepositMachineRepository
    {
        public Task<DepositMachine?> GetByIdAsync(DepositMachineId Id, CancellationToken cancellation);

        void CreateMachine(DepositMachine machine);

    }
}
