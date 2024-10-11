using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IAddressService
{
    Task <IEnumerable<AddressDto>> GetAllAddressesAsync();
    Task<AddressDto> GetAddressAsync(Guid id);
    Task<AddressDto> AddAddressAsync(AddAddressDto addressDto);
    Task DeleteAddressAsync(Guid id);
    Task UpdateAddressAsync(Guid id, AddAddressDto addressDto);
}