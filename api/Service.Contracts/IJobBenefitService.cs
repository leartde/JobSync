using Shared.DataTransferObjects.JobBenefitDtos;

namespace Service.Contracts;

public interface IJobBenefitService
{
    Task<IEnumerable<ViewJobBenefitDto>> GetBenefitsForJobAsync(Guid employerId, Guid jobId);
    Task<IEnumerable<ViewJobBenefitDto>> AddBenefitsForJobAsync(Guid employerId, Guid jobId, IEnumerable<AddJobBenefitDto> benefitDtos);
    Task DeleteBenefitsForJobAsync(Guid employerId, Guid jobId, IEnumerable<ViewJobBenefitDto> benefitDtos);
}