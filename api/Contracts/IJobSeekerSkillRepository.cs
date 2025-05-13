using Entities.Models;

namespace Contracts;

public interface IJobSeekerSkillRepository
{
    Task<IEnumerable<JobSeekerSkill>> GetAllJobSeekerSkillsAsync();
    Task<JobSeekerSkill> GetJobSeekerSkillAsync(Guid jobSeekerId, Guid skillId);
    Task AddJobSeekerSkillsAsync(List<JobSeekerSkill> jobSeekerSkills);
    void DeleteJobSeekerSkills(List<JobSeekerSkill> jobSeekerSkills);
    void DeleteJobSeekerSkill(JobSeekerSkill jobSeekerSkill);
}