using Shared.DataTransferObjects.JobSeekerDtos;

namespace Service.Contracts;

public interface IJobSeekerService
{
    Task<IEnumerable<ViewJobSeekerDto>> GetAllJobSeekersAsync();
    Task<ViewJobSeekerDto> GetJobSeekerAsync(Guid id);
    Task<AddJobSeekerDto> AddJobSeekerAsync(AddJobSeekerDto jobSeekerDto);
    Task DeleteJobSeekerAsync(Guid id);
    Task<UpdateJobSeekerDto> UpdateJobSeekerAsync(Guid id, UpdateJobSeekerDto jobSeekerDto);
}