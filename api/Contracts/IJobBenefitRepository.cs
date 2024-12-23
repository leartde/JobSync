using Entities.Models;

namespace Contracts;

public interface IJobBenefitRepository
{
    Task<IEnumerable<JobBenefit>> GetBenefitsForJobAsync(Job job);
    Task AddBenefitAsync(JobBenefit jobBenefit);
    Task AddBenefitsAsync(List<JobBenefit> jobBenefits);
    void DeleteBenefit(JobBenefit jobBenefit);
    void DeleteBenefits(List<JobBenefit> jobBenefits);
}