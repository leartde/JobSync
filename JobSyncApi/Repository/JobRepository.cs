using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class JobRepository : RepositoryBase<Job>, IJobRepository
{
    public JobRepository(RepositoryContext context) : base(context)
    {
    }


    public async Task<IEnumerable<Job>> GetAllJobsAsync()
    {
        return await FindAll()
            .Include(j => j.Employer)
            .Include(j => j.Location)
            .Include(j => j.Skills)
            .ThenInclude(s => s.Skill)
            .OrderBy(j => j.Employer)
            .ToListAsync();
    }

    public async Task<Job?> GetJobAsync(Guid id)
    {
        return await FindByCondition(j => j.Id.Equals(id))
            .Include(j => j.Employer)
            .Include(j => j.Location)
            .Include(j => j.Skills)
            .SingleOrDefaultAsync();
    }

    public void AddJob(Job job)
    {
        Create(job);
    }

    public void DeleteJob(Job job)
    {
        Delete(job);
    }

    public void UpdateJob(Job job)
    {
        Update(job);
    }
}