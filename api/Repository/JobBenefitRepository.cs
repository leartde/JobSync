using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

internal sealed class JobBenefitRepository : RepositoryBase<JobBenefit>, IJobBenefitRepository
{
    public JobBenefitRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<IEnumerable<JobBenefit>> GetBenefitsForJobAsync(Guid jobId)
    {
        return await FindByCondition(b => b.JobId.Equals(jobId))
            .ToListAsync();
    }

    public void AddBenefit(JobBenefit jobBenefit)
    {
        Create(jobBenefit);
    }

    public void AddBenefits(List<JobBenefit> jobBenefits)
    {
        CreateBulk(jobBenefits);
    }

    public void DeleteBenefit(JobBenefit jobBenefit)
    {
        Delete(jobBenefit);
    }
}