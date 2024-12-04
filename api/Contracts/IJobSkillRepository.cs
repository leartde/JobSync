using Entities.Models;

namespace Contracts;

public interface IJobSkillRepository
{
    Task<IEnumerable<JobSkill>> GetAllJobSkillsAsync();
    Task<JobSkill?> GetJobSkillAsync(Guid jobId, Guid skillId);
    void AddJobSkill(JobSkill jobSkill);
    void DeleteJobSkill(JobSkill jobSkill);
}