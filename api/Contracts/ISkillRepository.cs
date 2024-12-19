using Entities.Models;

namespace Contracts;

public interface ISkillRepository
{
    Task<IEnumerable<Skill>> GetAllSkillsAsync();
    Task<Skill> GetSkillAsync(Guid id);
    Task<Skill?> GetSkillByNameAsync(string name);
    void AddSkill(Skill skill);
    void AddSkills(List<Skill> skills);
    void UpdateSkill(Skill skill);
    void DeleteSkill(Skill skill);
}