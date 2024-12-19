using Entities.Models;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.AddressDtos;

namespace Service.Contracts;

public interface IAddressService
{
    
    Task<ViewAddressDto> GetAddressForJobAsync(Guid employerId, Guid jobId);
    Task<ViewAddressDto> GetAddressForJobSeekerAsync(Guid jobSeekerId);
    Task<ViewAddressDto> AddAddressForJobAsync(Guid employerId, Guid jobId, AddAddressDto addressDto);
    Task<ViewAddressDto> AddAddressForJobSeekerAsync(Guid jobSeekerId, AddAddressDto addressDto);
    Task DeleteAddressForJobAsync(Guid employerId, Guid jobId);
    Task DeleteAddressForJobSeekerAsync(Guid jobSeekerId);
    Task<ViewAddressDto> UpdateAddressForJobAsync(Guid employerId, Guid jobId, UpdateAddressDto addressDto);
    Task<ViewAddressDto> UpdateAddressForJobSeekerAsync(Guid jobSeekerId, UpdateAddressDto addressDto);
}