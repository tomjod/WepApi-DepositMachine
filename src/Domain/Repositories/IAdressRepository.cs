using Domain.Entities.Addresses;

namespace Domain.Repositories;

public interface IAddressRepository
{
    void CreateAddress(Address address);
}
