using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Branches;
using Domain.Entities.Deposits;

namespace Domain.Repositories
{
    public interface IDepositRepository
    {
        Task CreateDepositAsync(Deposit deposit);

        Task<IEnumerable<Deposit?>> GetDepositsAsync();

        Task<Deposit?> GetDepositByIdAsync(TransactionId id);

        Task<Deposit?> GetDepositByBrachIdAsync(BranchId id);

        Task CreateDepositLineItemAsync(DepositLineItem depositLineItem);

    }
}
