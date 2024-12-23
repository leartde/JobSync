using Contracts;
using Entities.Enums;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.JobBenefitDtos;
using Shared.Mapping;

namespace Service;

public class JobBenefitService : IJobBenefitService
{
    private readonly IRepositoryManager _repository;

    public JobBenefitService(IRepositoryManager repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<ViewJobBenefitDto>> GetBenefitsForJobAsync(Guid employerId,Guid jobId)
    {
        Job job = await _repository.Job.GetJobForEmployerAsync(employerId, jobId);
        IEnumerable<JobBenefit> benefits = await _repository.JobBenefit.GetBenefitsForJobAsync(job);
        return benefits.Select(b => b.ToDto());

    }

    public async Task<IEnumerable<ViewJobBenefitDto>> AddBenefitsForJobAsync(Guid employerId,Guid jobId, IEnumerable<AddJobBenefitDto> benefitDtos)
    {
        if (!benefitDtos.Any()) throw new BadRequestException("List of benefits is empty");
        Job job = await _repository.Job.GetJobForEmployerAsync(employerId, jobId);
        List<JobBenefit> benefitsToAdd = benefitDtos.Select(benefitDto =>
        {
            JobBenefit benefit = new JobBenefit { JobId = job.Id };
            benefitDto.ToEntity(benefit);
            return benefit;
        }).ToList();
        await _repository.JobBenefit.AddBenefitsAsync(benefitsToAdd);
        await _repository.SaveAsync();
        return benefitsToAdd.Select(b => b.ToDto());

    }

    public async Task DeleteBenefitsForJobAsync(Guid employerId, Guid jobId, IEnumerable<ViewJobBenefitDto> benefitDtos)
    {
        if (!benefitDtos.Any()) throw new BadRequestException("List of benefits is empty");
        Job job = await _repository.Job.GetJobForEmployerAsync(employerId, jobId);
        List<JobBenefit> benefitsToDelete = benefitDtos.Select(benefitDto =>
        {
            JobBenefit benefit = new JobBenefit { JobId = job.Id };
            benefitDto.ToEntity(benefit);
            return benefit;
        }).ToList();

        _repository.JobBenefit.DeleteBenefits(benefitsToDelete);
        await _repository.SaveAsync();
    }
}