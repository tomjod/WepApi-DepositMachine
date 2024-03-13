using Domain.Entities.ApiKeys;
using Domain.Entities.Branches;
using Domain.Entities.Clients;

namespace Domain;

public interface IApiKeyRepository
{
    void CreateApiKey(ApiKey apiKey);
}
