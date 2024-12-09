using Entities.Models;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.AddressDtos;

namespace Service.Contracts;

public interface IAddressService
{
    
    Task<ViewAddressDto> GetAddressForJobAsync(Guid employerId, Guid jobId);
    Task<ViewAddressDto> GetAddressForJobSeekerAsync(Guid jobSeekerId);
    Task<Address> AddAddressForJobAsync(Guid employerId, Guid jobId, AddAddressDto addressDto);
    Task<Address> AddAddressForJobSeekerAsync(Guid jobSeekerId, AddAddressDto addressDto);
    Task DeleteAddressForJobAsync(Guid employerId, Guid jobId);
    Task DeleteAddressForJobSeekerAsync(Guid jobSeekerId);
    Task<Address> UpdateAddressForJobAsync(Guid employerId, Guid jobId, UpdateAddressDto addressDto);
    Task<Address> UpdateAddressForJobSeekerAsync(Guid jobSeekerId, UpdateAddressDto addressDto);
}