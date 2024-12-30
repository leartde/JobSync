using Entities.Models;

namespace Contracts;

public interface ISkillRepository
{
    Task<IEnumerable<Skill>> GetAllSkillsAsync();
    Task<Skill> GetSkillAsync(Guid id);
    Task<Skill?> GetSkillByNameAsync(string name);
    Task<List<Skill>> GetSkillsByIdAsync(List<Guid> ids);
    Task AddSkillAsync(Skill skill);
    Task AddSkillsAsync(List<Skill> skills);
    void UpdateSkill(Skill skill);
    void DeleteSkill(Skill skill);
    void DeleteSkills(List<Skill> skills);
}