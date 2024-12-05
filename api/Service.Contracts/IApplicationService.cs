using Shared.DataTransferObjects.ApplicationDtos;

namespace Service.Contracts;

public interface IApplicationService
{
    Task<IEnumerable<ViewApplicationDto>> GetApplicationsForJobSeekerAsync(Guid jobSeekerId);
    Task<ViewApplicationDto> GetApplicationForJobSeekerAsync(Guid jobSeekerId, Guid applicationId);
    Task<IEnumerable<ViewApplicationDto>> GetApplicationsForJobAsync(Guid employerId, Guid jobId);
    Task<ViewApplicationDto> GetApplicationForJobAsync(Guid employerId,Guid jobId, Guid applicationId);
    Task<AddApplicationDto> AddApplicationAsync(AddApplicationDto applicationDto);
    Task<UpdateApplicationDto> UpdateApplicationAsync(UpdateApplicationDto applicationDto);
    Task DeleteApplicationAsync(Guid jobSeekerId, Guid applicationId);
}