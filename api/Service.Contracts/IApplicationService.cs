using Entities.Models;
using Shared.DataTransferObjects.ApplicationDtos;

namespace Service.Contracts;

public interface IApplicationService
{
    Task<IEnumerable<ViewApplicationDto>> GetApplicationsForJobSeekerAsync(Guid jobSeekerId);
    Task<ViewApplicationDto> GetApplicationForJobSeekerAsync(Guid jobSeekerId, Guid applicationId);
    Task<IEnumerable<ViewApplicationDto>> GetApplicationsForJobAsync(Guid employerId, Guid jobId);
    Task<ViewApplicationDto> GetApplicationForJobAsync(Guid employerId,Guid jobId, Guid applicationId);
    Task<Application> AddApplicationAsync(Guid jobId,AddApplicationDto applicationDto);
    Task<Application> UpdateApplicationAsync(UpdateApplicationDto applicationDto);
    Task DeleteApplicationAsync(Guid jobSeekerId, Guid applicationId);
}