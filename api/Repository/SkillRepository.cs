using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

internal sealed class SkillRepository : RepositoryBase<Skill>, ISkillRepository
{
    public SkillRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
    {
        return await  FindAll().OrderBy(s => s.Industry)
            .ToListAsync();
    }

    public async Task<Skill> GetSkillAsync(Guid id)
    {
        return await FindByCondition(s => s.Id.Equals(id))
            .SingleAsync();
    }

    public async Task<Skill?> GetSkillByNameAsync(string name)
    {
        return await FindByCondition(s => s.Name.Equals(name))
            .FirstOrDefaultAsync();
    }

    public async Task<List<Skill>> GetSkillsByIdAsync(List<Guid> ids)
    {
        return await FindByCondition(s => ids.Contains(s.Id))
            .ToListAsync();
    }

    public async Task AddSkillAsync(Skill skill)
    {
        await Create(skill);
    }

    public async Task AddSkillsAsync(List<Skill> skills)
    {
        await CreateBulk(skills);
    }

    public void UpdateSkill(Skill skill)
    {
        Update(skill);
    }

    public void DeleteSkill(Skill skill)
    {
        Delete(skill);
    }

    public void DeleteSkills(List<Skill> skills)
    {
        DeleteBulk(skills);
    }
}