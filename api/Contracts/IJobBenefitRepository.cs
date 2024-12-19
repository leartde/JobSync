using Entities.Models;

namespace Contracts;

public interface IJobBenefitRepository
{
    Task<IEnumerable<JobBenefit>> GetBenefitsForJobAsync(Guid jobId);
    void AddBenefit(JobBenefit jobBenefit);
    void AddBenefits(List<JobBenefit> jobBenefits);
    void DeleteBenefit(JobBenefit jobBenefit);
}