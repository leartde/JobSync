using Entities.Models;

namespace Contracts;

public interface IAddressRepository
{
    Task <IEnumerable<Address>> GetAllAddressesAsync();
    Task<Address?> GetAddressAsync(Guid id);
    void AddAddress(Address address);
    void DeleteAddress(Address address);
    void UpdateAddress(Address address);
}