using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class SkillRepository : RepositoryBase<Skill>, ISkillRepository
{
    public SkillRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
    {
        return await  FindAll().OrderBy(s => s.Industry)
            .ToListAsync();
    }

    public async Task<Skill?> GetSkillAsync(Guid id)
    {
        return await FindByCondition(s => s.Id.Equals(id))
            .SingleOrDefaultAsync();
    }

    public void AddSkill(Skill skill)
    {
        Create(skill);
    }

    public void UpdateSkill(Skill skill)
    {
        Update(skill);
    }

    public void DeleteSkill(Skill skill)
    {
        Delete(skill);
    }
}