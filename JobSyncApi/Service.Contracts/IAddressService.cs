using Entities.Models;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.AddressDtos;

namespace Service.Contracts;

public interface IAddressService
{
    Task <IEnumerable<ViewAddressDto>> GetAllAddressesAsync();
    Task<ViewAddressDto> GetAddressAsync(Guid id);
    Task<ViewAddressDto> AddAddressAsync(AddAddressDto addressDto);
    Task DeleteAddressAsync(Guid id);
    Task UpdateAddressAsync(Guid id, UpdateAddressDto addressDto);
}