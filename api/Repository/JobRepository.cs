using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

internal sealed class JobRepository : RepositoryBase<Job>, IJobRepository
{
    public JobRepository(RepositoryContext context) : base(context)
    {
    }


    public async Task<IEnumerable<Job>> GetAllJobsAsync()
    {
        return await FindAll()
            .ToListAsync();
    }

    public async Task<IEnumerable<Job>> GetJobsForEmployerAsync(Guid employerId)
    {
        return await FindByCondition(j => j.EmployerId.Equals(employerId))
            .Include(j => j.Employer)
            .Include(j => j.Address)
            .Include(j => j.Skills )
            .OrderBy(j => j.Employer)
            .ToListAsync();
    }

    public async Task<Job?> GetJobForEmployerAsync(Guid employerId, Guid id)
    {
        return await FindByCondition(j=>j.EmployerId.Equals(employerId)&& j.Id.Equals(id) )
            .Include(j => j.Employer)
            .Include(j => j.Address)
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