using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

internal sealed class JobBenefitRepository : RepositoryBase<JobBenefit>, IJobBenefitRepository
{
    public JobBenefitRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<IEnumerable<JobBenefit>> GetBenefitsForJobAsync(Job job)
    {
        return await FindByCondition(b => b.JobId.Equals(job.Id))
            .ToListAsync();
    }

    public async Task AddBenefitAsync(JobBenefit jobBenefit)
    {
        await Create(jobBenefit);
    }

    public async Task AddBenefitsAsync(List<JobBenefit> jobBenefits)
    {
        await CreateBulk(jobBenefits);
    }

    public void DeleteBenefit(JobBenefit jobBenefit)
    {
        Delete(jobBenefit);
    }

    public void DeleteBenefits(List<JobBenefit> jobBenefits)
    {
        DeleteBulk(jobBenefits);
    }
}