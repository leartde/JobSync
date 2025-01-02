using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IJobSeekerRepository
{
    Task<PagedList<JobSeeker>> GetAllJobSeekersAsync(JobSeekerParameters jobSeekerParameters);
    Task<JobSeeker> GetJobSeekerAsync(Guid id);
    Task AddJobSeekerAsync(JobSeeker jobSeeker);
    void DeleteJobSeeker(JobSeeker jobSeeker);
    void UpdateJobSeeker(JobSeeker jobSeeker);
}