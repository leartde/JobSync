using Entities.Models;


namespace Contracts;

public interface IJobRepository
{
     Task <IEnumerable<Job>> GetAllJobsAsync();
     Task<Job?> GetJobAsync(Guid id);
     void AddJob(Job job);
     void DeleteJob(Job job);
     void UpdateJob(Job job);
}