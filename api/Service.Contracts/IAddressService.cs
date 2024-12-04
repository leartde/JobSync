using Entities.Models;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.AddressDtos;

namespace Service.Contracts;

public interface IAddressService
{
    
    Task<ViewAddressDto> GetAddressForJobAsync(Guid employerId, Guid jobId);
    Task<ViewAddressDto> GetAddressForJobSeekerAsync(Guid jobSeekerId);
    Task<AddAddressDto> AddAddressForJobAsync(Guid employerId, Guid jobId, AddAddressDto addressDto);
    Task<AddAddressDto> AddAddressForJobSeekerAsync(Guid jobSeekerId, AddAddressDto addressDto);
    Task DeleteAddressForJobAsync(Guid employerId, Guid jobId);
    Task DeleteAddressForJobSeekerAsync(Guid jobSeekerId);
    Task UpdateAddressForJobAsync(Guid employerId, Guid jobId, UpdateAddressDto addressDto);
    Task UpdateAddressForJobSeekerAsync(Guid jobSeekerId, UpdateAddressDto addressDto);
}