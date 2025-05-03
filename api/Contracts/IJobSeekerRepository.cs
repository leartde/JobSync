using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IJobSeekerRepository
{
    Task<PagedList<JobSeeker>> GetAllJobSeekersAsync(JobSeekerParameters jobSeekerParameters);
    Task<JobSeeker> GetJobSeekerAsync(Guid id);
    Task<JobSeeker> GetJobSeekerByUserIdAsync(Guid userId);
    Task AddJobSeekerAsync(JobSeeker jobSeeker);
    void DeleteJobSeeker(JobSeeker jobSeeker);
    void UpdateJobSeeker(JobSeeker jobSeeker);
}