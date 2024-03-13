using Domain.Repositories;
using Domain.Entities.Addresses;

namespace Infrastructure.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly AppDbContext _DbContext;

    public AddressRepository(AppDbContext dbContext)
    {
        _DbContext = dbContext;
    }

    public void CreateAddress(Address address) =>
    _DbContext.Set<Address>().Add(address);

}
