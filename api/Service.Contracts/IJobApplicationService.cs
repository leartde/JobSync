using Entities.Models;
using Shared.DataTransferObjects.JobApplicationDtos;

namespace Service.Contracts;

public interface IJobApplicationService
{
    Task<ViewJobApplicationDto> GetApplicationAsync(Guid jobId, Guid jobSeekerId);
    Task<IEnumerable<ViewJobApplicationDto>> GetApplicationsForJobSeekerAsync(Guid jobSeekerId);
    Task<IEnumerable<ViewJobApplicationDto>> GetApplicationsForJobAsync(Guid employerId, Guid jobId);
    Task<ViewJobApplicationDto> AddApplicationAsync(Guid jobId,AddJobApplicationDto jobApplicationDto);
    Task<ViewJobApplicationDto> UpdateApplicationAsync(UpdateJobApplicationDTO jobApplicationDto);
    Task DeleteApplicationAsync(Guid jobSeekerId, Guid applicationId);
}