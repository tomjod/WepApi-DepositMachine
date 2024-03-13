using Application.Abstractions.Messaging;
using Domain.Entities.Branches;
using Domain.Entities.Denominations;
using Domain.Entities.Deposits;
using Domain.Entities.Users;
using Domain.Repositories;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Deposits.Commands
{
    public class CreateDepositCommandHandler : ICommandHandler<CreateDepositCommand, TransactionId>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepositRepository _depositRepository;

        public CreateDepositCommandHandler(IUnitOfWork unitOfWork, IDepositRepository depositRepository)
        {
            _unitOfWork = unitOfWork;
            _depositRepository = depositRepository;
        }

        public async Task<Result<TransactionId>> Handle(CreateDepositCommand request, CancellationToken cancellationToken)
        {
            Result<TransactionId> transactionResult = TransactionId.Create(request.TransactionId);

            if (transactionResult.IsFailure)
            {
                return (Result<TransactionId>)Result.Failure(transactionResult.Error);
            }

            var deposit = Deposit.Create(
                transactionResult.Value,
                new UserId(request.UserId),
                new BranchId(request.BranchId),
                request.DepositDate);

            if (!deposit.IsSuccess)
            {
                return Result.Failure<TransactionId>(deposit.Error);
            }

            foreach(var item in request.DenominationPieces) 
            { 
              var result = deposit.Value.AddLineItem(
                    new DenominationId(item.DenominationId),
                    item.Pieces);
                if (!result.IsSuccess) 
                {
                    return Result.Failure<TransactionId>(result.Error);
                }
            }

            await _depositRepository.CreateDepositAsync(deposit.Value);

            foreach (var depositLineItem in deposit.Value.DepositLineItem)
            {
                await _depositRepository.CreateDepositLineItemAsync(depositLineItem);
            }

            return deposit.Value.Id;
           
        }
    }
}
