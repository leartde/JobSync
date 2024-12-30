using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

internal sealed class JobSeekerSkillRepository : RepositoryBase<JobSeekerSkill>, IJobSeekerSkillRepository
{
    public JobSeekerSkillRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<IEnumerable<JobSeekerSkill>> GetAllJobSeekerSkillsAsync()
    {
        return await FindAll()
            .Include(js => js.JobSeeker)
            .Include(js => js.Skill)
            .ToListAsync();
    }

    public async Task<JobSeekerSkill> GetJobSeekerSkillAsync(Guid jobSeekerId, Guid skillId)
    {
        return await FindByCondition(js => js.JobSeekersId.Equals(jobSeekerId) && js.SkillsId.Equals(skillId))
            .Include(js => js.JobSeeker)
            .Include(js => js.Skill)
            .SingleAsync();
    }

    public async Task AddJobSeekerSkillsAsync(List<JobSeekerSkill> jobSeekerSkills)
    {
        await CreateBulk(jobSeekerSkills);
    }

    public void DeleteJobSeekerSkill(JobSeekerSkill jobSeekerSkill)
    {
        Delete(jobSeekerSkill);
    }
}