using Domain.Entities.Bags;
using Domain.Entities.Branches;
using Domain.Entities.Users;
using Domain.ValueObjects;

namespace Domain.Entities.CashBagWithdrawalEvents
{
    public class CashBagWithdrawalEvent
    {
        private CashBagWithdrawalEvent()
        {
        }

        public Guid Id { get; private set; }
        public BranchId BranchId { get; private set; }
        public BagId BagId { get; private set; }
        public UserId UserId { get; private set; }
        public DateTime Date { get; private set; }
        public Cash Cash { get; private set; }


        public CashBagWithdrawalEvent RegisterBagWithdrawal(
            BranchId branchId,
            BagId bagId,
            Cash amount,
            UserId userId)
        {
            var withdrawal = new CashBagWithdrawalEvent
            {
                Id = Guid.NewGuid(),
                BranchId = branchId,
                BagId = bagId,
                UserId = userId,
                Date = DateTime.UtcNow,
                Cash = amount
            };

            return withdrawal;
        }
    }
}
