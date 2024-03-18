using Application.Abstractions.Messaging;
using Domain.Entities.DepositMachines;
using Domain.Repositories;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DepositMachines.Queries.GetDepositMachineById
{
    public class GetDepositMachineByIdQueryHandler : IQueryHandler<GetDepositMachineByIdQuery, DepositMachine>
    {
        private readonly IDepositMachineRepository _depositMachineRepository;

        public GetDepositMachineByIdQueryHandler(IDepositMachineRepository depositMachineRepository)
        {
            _depositMachineRepository = depositMachineRepository;
        }

        public async Task<Result<DepositMachine>> Handle(GetDepositMachineByIdQuery request, CancellationToken cancellationToken)
        {
           
            var depositMachineId = new DepositMachineId(request.Id);

            var depositMachine = await _depositMachineRepository
                .GetByIdAsync(depositMachineId, cancellationToken);

            if (depositMachine == null)
            {
                return Result.Failure<DepositMachine>(new Error(
                    "DepositMachine.NotFound",
                    $"DepositMachine with the specified id {request.Id} is not found"));
            }

            return depositMachine;
        }
    }
}
