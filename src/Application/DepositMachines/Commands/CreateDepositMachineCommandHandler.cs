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
using Application.DepositMachines.Commands;
using Application.Machine.Commands;
using Domain.Entities.BanknoteValidationModules;

namespace Application.DepositMachines.Commands
{
    public class CreateDepositMachineCommandHandler : ICommandHandler<CreateDepositMachineCommand, DepositMachineId>
    {
        private readonly IDepositMachineRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDepositMachineCommandHandler(IDepositMachineRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
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
            
            
            var depositMachine = DepositMachine.Create(
                new BanknoteValidationModuleId(request.BanknoteValidationModuleId),
                request.SerialNumber,
                request.ManufactureYear);

            _repository.CreateMachine(depositMachine.Value);

            await _unitOfWork.SaveChangesAsync();

            return depositMachine.Value.Id;
        }
    }
}
