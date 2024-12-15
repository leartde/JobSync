using Entities.Models;
using Shared.DataTransferObjects.JobSeekerDtos;

namespace Service.Contracts;

public interface IJobSeekerService
{
    Task<IEnumerable<ViewJobSeekerDto>> GetAllJobSeekersAsync();
    Task<ViewJobSeekerDto> GetJobSeekerAsync(Guid id);
    Task<ViewJobSeekerDto> AddJobSeekerAsync(AddJobSeekerDto jobSeekerDto);
    Task<ViewJobSeekerDto> UpdateJobSeekerAsync(Guid id, UpdateJobSeekerDto jobSeekerDto);
    Task DeleteJobSeekerAsync(Guid id);
    
}