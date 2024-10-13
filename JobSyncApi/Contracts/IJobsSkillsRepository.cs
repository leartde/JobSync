using Entities.Models;

namespace Contracts;

public interface IJobsSkillsRepository
{
    Task<IEnumerable<JobsSkills>> GetAllJobsSkillsAsync();
    Task<JobsSkills?> GetJobsSkillsAsync(Guid jobId, Guid skillId);
    void AddJobsSkills(JobsSkills jobsSkills);
    void DeleteJobsSkills(JobsSkills jobsSkills);
}