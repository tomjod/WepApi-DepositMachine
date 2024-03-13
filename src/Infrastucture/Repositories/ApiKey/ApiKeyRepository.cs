using Domain;
using Domain.Entities.ApiKeys;
using Domain.Entities.Branches;

namespace Infrastructure;

public class ApiKeyRepository : IApiKeyRepository
{
    private  readonly AppDbContext _dbContext;

    public ApiKeyRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreateApiKey(ApiKey apiKey) => 
        _dbContext.Set<ApiKey>().Add(apiKey);

}
