using Entities.Models;
using Shared.DataTransferObjects.ApplicationDtos;

namespace Service.Contracts;

public interface IJobApplicationService
{
    Task<IEnumerable<ViewApplicationDto>> GetApplicationsForJobSeekerAsync(Guid jobSeekerId);
    Task<IEnumerable<ViewApplicationDto>> GetApplicationsForJobAsync(Guid employerId, Guid jobId);
    Task<ViewApplicationDto> AddApplicationAsync(Guid jobId,AddApplicationDto applicationDto);
    Task<ViewApplicationDto> UpdateApplicationAsync(UpdateApplicationDto applicationDto);
    Task DeleteApplicationAsync(Guid jobSeekerId, Guid applicationId);
}