using Entities.Models;

namespace Contracts;

public interface IJobApplicationRepository
{
    Task<IEnumerable<JobApplication>> GetApplicationsForJobSeekerAsync(JobSeeker jobSeeker);
    Task<IEnumerable<JobApplication>> GetApplicationsForJobAsync(Job job);
  
    void AddApplication(JobApplication jobApplication);
    void UpdateApplication(JobApplication jobApplication);
    void DeleteApplication(JobApplication jobApplication);
}