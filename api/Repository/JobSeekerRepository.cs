using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

internal sealed class JobSeekerRepository : RepositoryBase<JobSeeker> , IJobSeekerRepository
{
    public JobSeekerRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<IEnumerable<JobSeeker>> GetAllJobSeekersAsync()
    {
        return await FindAll()
            .Include(js => js.Address)
            .Include(js => js.Applications)
            .Include(js => js.Skills)
            .OrderBy(js => js.LastName)
            .ToListAsync();
    }

    public async Task<JobSeeker> GetJobSeekerAsync(Guid id)
    {
        return await FindByCondition(js => js.Id.Equals(id))
            .Include(js => js.Address)
            .Include(js => js.Applications)
            .Include(js => js.Skills)
            .SingleAsync();
    }

    public async Task AddJobSeekerAsync(JobSeeker jobSeeker)
    {
       await Create(jobSeeker);
    }

    public void DeleteJobSeeker(JobSeeker jobSeeker)
    {
        Delete(jobSeeker);
    }

    public void UpdateJobSeeker(JobSeeker jobSeeker)
    {
        Update(jobSeeker);
    }
}