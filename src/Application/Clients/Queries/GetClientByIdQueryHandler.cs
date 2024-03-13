using Application.Abstractions.Messaging;
using Domain.Entities.Clients;
using Domain.Errors;
using Domain.Repositories;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clients.Queries
{
    public class GetClientByIdQueryHandler : IQueryHandler<GetClientByIdQuery, Client>
    {
        private readonly IClientRepository _clientRepository;

        public GetClientByIdQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Result<Client>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            if (request is null) 
            {
                return Result.Failure<Client>(new Error(
                    "request.IsNull",
                    "Body is null"));
            }

            var clientId = new ClientId(request.Id);

            var client = await _clientRepository.GetClientById(clientId);

            if (client is null) 
            {
                return Result.Failure<Client>(
                    DomainErrors.Client.NotFound(request.Id));
            }

            return Result.Success(client);
        }
    }
}
