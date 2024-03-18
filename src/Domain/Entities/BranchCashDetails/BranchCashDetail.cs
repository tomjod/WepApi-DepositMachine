using Domain.Entities.Bags;
using Domain.Entities.Branches;
using Domain.Entities.Deposits;
using Domain.ValueObjects;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.BranchCashDetails
{
    public class BranchCashDetails
    {
        public BranchCashDetailId Id { get; private set; }

        public BranchId BranchId { get; private set; }

        public BagId BagId { get; private set; }

        public Cash CurrentValue { get; private set; }

        public Cash LastValue { get; private set; }

        public DateTime? LastEmptied { get; private set; }

        private BranchCashDetails(
            BranchId branchId,
            BagId bagId)
            
        {
            var InitialValue = Cash.Add(0, 0);

            Id = new BranchCashDetailId(Guid.NewGuid());
            BranchId = branchId;
            BagId = bagId;
            CurrentValue = InitialValue;
            LastValue = InitialValue;
            LastEmptied = null;
        }

        public static Result<BranchCashDetails> Create(
            BranchId branchId,
            BagId bagId)
        {
            if (branchId is null)
            {
                return Result.Failure<BranchCashDetails>(new Error(
                    "BranchCashDetails.IsNull",
                    "BranchId can't be null"));
            }


           var branchCashDetail = new BranchCashDetails(
                branchId,
                bagId);

            return Result.Success(branchCashDetail);
                
        }

        public void UpdateCurrentAmountAndPieces(int amount, int pieces)
        {
            if (amount <= 0 || pieces <= 0)
            {
                return;
            }

            CurrentValue.Amount += amount;
            CurrentValue.Pieces += pieces;
        }

        private void AddToAmountSinceLastEmptied(int amount)
        {
            if (amount < 0)
            {
                throw new Exception("La cantidad no puede ser negativa");
            }

           LastValue.Amount = amount;
        }

        public Result EmptyMachine()
        {
            AddToAmountSinceLastEmptied(CurrentValue.Amount);

            CurrentValue.Amount = 0;
            CurrentValue.Pieces = 0;
            LastEmptied = DateTime.UtcNow;



            return Result.Success();
        }
    }
}
