using Entities.Models;

namespace Contracts;

public interface IJobSeekerRepository
{
    Task<IEnumerable<JobSeeker>> GetAllJobSeekersAsync();
    Task<JobSeeker?> GetJobSeekerAsync(Guid id);
    void AddJobSeeker(JobSeeker jobSeeker);
    void DeleteJobSeeker(JobSeeker jobSeeker);
    void UpdateJobSeeker(JobSeeker jobSeeker);
}