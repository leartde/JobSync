using Shared.DataTransferObjects.JobDtos;

namespace Service.Contracts;

public interface IJobService
{
    Task<IEnumerable<ViewJobDto>> GetAllJobsAsync();
    Task<IEnumerable<ViewJobDto>> GetJobsForEmployerAsync(Guid employerId);
    Task<ViewJobDto> GetJobForEmployerAsync(Guid employerId, Guid id);
    Task<AddJobDto> AddJobForEmployerAsync(Guid employerId, AddJobDto jobDto);
    Task<UpdateJobDto> UpdateJobForEmployerAsync(Guid employerId, Guid id, UpdateJobDto jobDto);
    Task DeleteJobForEmployerAsync(Guid employerId, Guid id);
}