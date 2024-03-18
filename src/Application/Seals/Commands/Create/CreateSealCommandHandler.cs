using Application.Abstractions.Messaging;
using Domain.Entities.Bags;
using Domain.Entities.DepositMachines;
using Domain.Entities.Seals;
using Domain.Repositories;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Seals.Commands.Create
{
    public class CreateSealCommandHandler : ICommandHandler<CreateSealCommand, SealId>
    {
        private readonly ISealRepository _sealRepository;
        private readonly IDepositMachineRepository _depositMachineRepository;
        private readonly IUnitOfWork _unitOfWork;
        

        public CreateSealCommandHandler(
            ISealRepository sealRepository, 
            IDepositMachineRepository depositMachineRepository,
            IUnitOfWork unitOfWork)
        {
            _sealRepository = sealRepository;
            _depositMachineRepository = depositMachineRepository;
            _unitOfWork = unitOfWork;
        }



        public async Task<Result<SealId>> Handle(CreateSealCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.SerialNumber))
            {
                return Result.Failure<SealId>(new Error(
                    "Seal.SerialNumberIsNull",
                    "The serial number can't be null"));
            }

            var depositMachineId = new DepositMachineId(request.DepositMachineId);
            var bagId = new BagId(request.BagId);

            var depositMachine = await _depositMachineRepository
                .GetByIdAsync(depositMachineId, cancellationToken);
            
            if (depositMachine == null)
            {
                return Result.Failure<SealId>(new Error(
                    "SealId.DepositMachineNotFound",
                    $"DepositMachine with Id {request.DepositMachineId} is not found"));
            }

            var seal = Seal.Create(request.SerialNumber, bagId, depositMachineId);

            _sealRepository.AddSeal(seal.Value);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success(seal.Value.Id);


        }
    }
}
