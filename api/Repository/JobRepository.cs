using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

internal sealed class JobRepository : RepositoryBase<Job>, IJobRepository
{
    public JobRepository(RepositoryContext context) : base(context)
    {
    }


    public async Task<PagedList<Job>> GetAllJobsAsync(JobParameters jobParameters)
    {
        List<Job> jobs = await FindAll()
            .Include(j => j.Employer)
            .Include(j => j.Address)
            .Include(j => j.Skills)
            .OrderBy(j => j.Employer)
            .Filter(jobParameters.JobType,jobParameters.HasMultipleSpots,jobParameters.IsTakingApplications)
            .Search(jobParameters.SearchTerm)
            .Skip((jobParameters.PageNumber - 1) * jobParameters.PageSize)
            .Take(jobParameters.PageSize)
            .Sort(jobParameters.OrderBy)
            
            .ToListAsync();

        int count = await FindAll()
            .Filter(jobParameters.JobType,jobParameters.HasMultipleSpots,jobParameters.IsTakingApplications)
            .Search(jobParameters.SearchTerm)
            .CountAsync();

        return new PagedList<Job>(jobs, count, jobParameters.PageNumber, jobParameters.PageSize);
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