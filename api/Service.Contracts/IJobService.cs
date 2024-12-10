using System.Dynamic;
using Entities.Models;
using Shared.DataTransferObjects.JobDtos;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IJobService
{
    Task<(IEnumerable<ExpandoObject> jobs,MetaData metaData)> GetAllJobsAsync(JobParameters jobParameters);
    Task<IEnumerable<ViewJobDto>> GetJobsForEmployerAsync(Guid employerId);
    Task<ViewJobDto> GetJobForEmployerAsync(Guid employerId, Guid id);
    Task<Job> AddJobForEmployerAsync(Guid employerId, AddJobDto jobDto);
    Task<Job> UpdateJobForEmployerAsync(Guid employerId, Guid id, UpdateJobDto jobDto);
    Task DeleteJobForEmployerAsync(Guid employerId, Guid id);
}