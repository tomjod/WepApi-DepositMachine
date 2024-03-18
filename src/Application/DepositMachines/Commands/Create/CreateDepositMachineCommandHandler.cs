using Application.Abstractions.Messaging;
using Domain.Entities.DepositMachines;
using Domain.Repositories;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.BanknoteValidationModules;

namespace Application.DepositMachines.Commands.Create
{
    public class CreateDepositMachineCommandHandler : ICommandHandler<CreateDepositMachineCommand, DepositMachineId>
    {
        private readonly IDepositMachineRepository _depositMachineRepository;
        private readonly IBanknoteValidationModuleRepository _banknoteValidationModuleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDepositMachineCommandHandler(
            IDepositMachineRepository repository,
            IBanknoteValidationModuleRepository banknoteValidationModuleRepository,
            IUnitOfWork unitOfWork)
        {
            _depositMachineRepository = repository;
            _banknoteValidationModuleRepository = banknoteValidationModuleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<DepositMachineId>> Handle(CreateDepositMachineCommand request, CancellationToken cancellationToken)
        {
            if (new BanknoteValidationModuleId(request.BanknoteValidationModuleId) == null)
            {
                return Result.Failure<DepositMachineId>(new Error(
                    "BanknoteValidationModuleId.IsNull",
                    "BanknoteValidationModuleId can't be null"));
            }

            var banknoteValidationModule = await _banknoteValidationModuleRepository
                .GetBanknoteValidationModuleAsync(
                new BanknoteValidationModuleId(request.BanknoteValidationModuleId), cancellationToken);

            if (banknoteValidationModule == null)
            {
                return Result.Failure<DepositMachineId>(new Error(
                    "DepositMachine.BanknoteValidationModuleNotFound",
                    $"BanknoteValidationModule specified {request.BanknoteValidationModuleId} is not found"));
            }

            var depositMachine = DepositMachine.Create(
                new BanknoteValidationModuleId(
                request.BanknoteValidationModuleId),
                request.SerialNumber,
                request.Model,
                request.ManufactureYear);

            _depositMachineRepository.CreateMachine(depositMachine.Value);

            await _unitOfWork.SaveChangesAsync();

            return depositMachine.Value.Id;
        }
    }
}
