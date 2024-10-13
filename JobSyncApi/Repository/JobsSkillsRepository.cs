using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class JobsSkillsRepository : RepositoryBase<JobsSkills>, IJobsSkillsRepository
{
    public JobsSkillsRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<IEnumerable<JobsSkills>> GetAllJobsSkillsAsync()
    {
        return await FindAll()
            .Include(js => js.Job)
            .Include(js => js.Skill)
            .OrderBy(j => j.JobId)
            .ToListAsync();

    }

    public async Task<JobsSkills?> GetJobsSkillsAsync(Guid jobId, Guid skillId)
    {
        return await FindByCondition(js => js.JobId.Equals(jobId)
                                           && js.SkillId.Equals(skillId))
            .Include(js => js.Job)
            .Include(js => js.Skill)
            .SingleOrDefaultAsync();
    }

    public void AddJobsSkills(JobsSkills jobsSkills)
    {
        Create(jobsSkills);
    }

    public void DeleteJobsSkills(JobsSkills jobsSkills)
    {
        Delete(jobsSkills);
    }
}