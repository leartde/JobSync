using Shared.DataTransferObjects.JobDtos;

namespace Service.Contracts;

public interface IJobService
{
    Task<IEnumerable<ViewJobDto>> GetAllJobsAsync();
    Task<ViewJobDto> GetJobAsync(Guid id);
    Task<AddJobDto> AddJobAsync(AddJobDto jobDto);
    Task<UpdateJobDto> UpdateJobAsync(Guid id, UpdateJobDto jobDto);
    Task DeleteJobAsync(Guid id);
}