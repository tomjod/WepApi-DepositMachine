using Application.Abstractions.Messaging;
using Domain.Entities.BanknoteValidationModules;
using Domain.Repositories;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BanknoteValidationModules.Commands.Create
{
    public class CreateBanknoteValidationModuleCommandHandler : ICommandHandler<CreateBanknoteValidationModuleCommand, BanknoteValidationModuleId>
    {
        private readonly IBanknoteValidationModuleRepository _banknoteValidationModuleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBanknoteValidationModuleCommandHandler(IBanknoteValidationModuleRepository banknoteValidationModuleRepository, IUnitOfWork unitOfWork)
        {
            _banknoteValidationModuleRepository = banknoteValidationModuleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<BanknoteValidationModuleId>> Handle(CreateBanknoteValidationModuleCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.SerialNumber))
            {
                return Result.Failure<BanknoteValidationModuleId>(new Error(
                    "SerialNumber.IsNull",
                    "Serial number can't be null"));
            }

            if (string.IsNullOrWhiteSpace(request.Model))
            {
                return Result.Failure<BanknoteValidationModuleId>(new Error(
                    "Model.IsNull",
                    "Model can't be null"));
            }

            if (!await _banknoteValidationModuleRepository
                .IsSerialUniqueAsync(request.SerialNumber))
            {
                return Result.Failure<BanknoteValidationModuleId>(new Error(
                    "BanknoteValidationModule.SerialIsNotUnique",
                    $"The serial number specified {request.SerialNumber} is not unique"));
            }

            var banknoteValidationModule = BanknoteValidationModule.Create(
                request.SerialNumber,
                request.Model,
                request.ManufactureYear);

             _banknoteValidationModuleRepository
                .CreateBanknoteValidationModule(banknoteValidationModule.Value);

            await _unitOfWork.SaveChangesAsync();

            return banknoteValidationModule.Value.Id;

        }
    }
}
