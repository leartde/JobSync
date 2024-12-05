using Entities.Models;

namespace Contracts;

public interface IApplicationRepository
{
    Task<IEnumerable<Application>> GetApplicationsForJobSeekerAsync(JobSeeker jobSeeker);
    Task<IEnumerable<Application>> GetApplicationsForJobAsync(Job job);
    Task<Application?> GetApplicationForJobSeekerAsync(JobSeeker jobSeeker, Guid applicationId);
    Task<Application?> GetApplicationForJobAsync(Job job, Guid applicationId);
    void AddApplication(Application application);
    void UpdateApplication(Application application);
    void DeleteApplication(Application application);
}