using Application.Abstractions.Messaging;
using Domain.Entities.BanknoteValidationModules;
using Domain.Errors;
using Domain.Repositories;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BanknoteValidationModules.Queries.GetBanknoteValidationModuleById
{
    public class GetBanknoteValidationModuleByIdQueryHandler : IQueryHandler<GetBanknoteValidationModuleByIdQuery, BanknoteValidationModule>
    {
        private readonly IBanknoteValidationModuleRepository _banknoteValidationModuleRepository;

        public GetBanknoteValidationModuleByIdQueryHandler(IBanknoteValidationModuleRepository banknoteValidationModuleRepository)
        {
            _banknoteValidationModuleRepository = banknoteValidationModuleRepository;
        }

        public async Task<Result<BanknoteValidationModule>> Handle(GetBanknoteValidationModuleByIdQuery request, CancellationToken cancellationToken)
        {
            var banknoteValidationModule = await _banknoteValidationModuleRepository
                .GetBanknoteValidationModuleAsync(request.Id);

            if (banknoteValidationModule == null)
            {
                Result<BanknoteValidationModule>.Failure(new Error(
                    "BanknoteValidationModule.NotFound",
                    $"Banknote Validation Modulo with Id {request.Id} not Found "));
            }

            return banknoteValidationModule;
        }
    }
}
