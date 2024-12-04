using Entities.Models;

namespace Contracts;

public interface ISkillRepository
{
    Task<IEnumerable<Skill>> GetAllSkillsAsync();
    Task<Skill?> GetSkillAsync(Guid id);
    void AddSkill(Skill skill);
    void UpdateSkill(Skill skill);
    void DeleteSkill(Skill skill);
}