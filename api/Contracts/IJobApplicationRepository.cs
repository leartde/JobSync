using Entities.Models;

namespace Contracts;

public interface IJobApplicationRepository
{
    Task<JobApplication> GetJobApplication(Guid jobId, Guid jobSeekerId);
    Task<IEnumerable<JobApplication>> GetApplicationsForJobSeekerAsync(JobSeeker jobSeeker);
    Task<IEnumerable<JobApplication>> GetApplicationsForJobAsync(Job job);
    Task AddApplicationAsync(JobApplication jobApplication);
    void UpdateApplication(JobApplication jobApplication);
    void DeleteApplication(JobApplication jobApplication);
}