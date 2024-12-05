using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository
{
    public ApplicationRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Application>> GetApplicationsForJobSeekerAsync(JobSeeker jobSeeker)
    {
        return await FindByCondition(a => a.JobSeekerId.Equals(jobSeeker.Id))
            .ToListAsync();
    }

    public async Task<IEnumerable<Application>> GetApplicationsForJobAsync(Job job)
    {
        return await FindByCondition(a => a.JobId.Equals(job.Id))
            .ToListAsync();
    }

    public async Task<Application?> GetApplicationForJobSeekerAsync(JobSeeker jobSeeker, Guid applicationId)
    {
        return await FindByCondition(a => a.JobSeekerId.Equals(jobSeeker.Id) && a.Id.Equals(applicationId))
            .FirstOrDefaultAsync();
    }

    public async Task<Application?> GetApplicationForJobAsync(Job job, Guid applicationId)
    {
        return await FindByCondition(a => a.JobId.Equals(job.Id) && a.Id.Equals(applicationId))
            .FirstOrDefaultAsync();
    }

    public void AddApplication(Application application)
    {
        Create(application);
    }

    public void UpdateApplication(Application application)
    {
        Update(application);
    }

    public void DeleteApplication(Application application)
    {
        Delete(application);
    }
}