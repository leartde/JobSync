using Entities.Models;

namespace Contracts;

public interface IJobSeekerSkillRepository
{
    Task<IEnumerable<JobSeekerSkill>> GetAllJobSeekerSkillsAsync();
    Task<JobSeekerSkill> GetJobSeekerSkillAsync(Guid jobSeekerId, Guid skillId);
    void AddJobSeekerSkill(JobSeekerSkill jobSeekerSkill);
    void DeleteJobSeekerSkill(JobSeekerSkill jobSeekerSkill);
}