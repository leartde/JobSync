using Contracts;
using Entities.Exceptions.JobExceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.JobDtos;
using Shared.Mapping;

namespace Service;

internal sealed class JobService : IJobService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public JobService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<ViewJobDto>> GetAllJobsAsync()
    {
        IEnumerable<Job> jobs = await _repository.Job.GetAllJobsAsync();
        return jobs.Select(j => j.MapJobDto());
    }

    public async Task<ViewJobDto> GetJobAsync(Guid id)
    {
        Job? job = await _repository.Job.GetJobAsync(id);
        if (job is null) throw new JobNotFoundException(id);
        return job.MapJobDto();
    }

    public async Task<AddJobDto> AddJobAsync(AddJobDto jobDto)
    {
        Address address = jobDto.Location.ReverseMapAddress();
        _repository.Address.AddAddress(address);
        Job job = jobDto.ReverseMapJob();
        job.AddressId = address.Id;
        _repository.Job.AddJob(job);
        if (jobDto.Skills != null)
        {
            IEnumerable<Skill> skills = jobDto.Skills.Select(s => s.ReverseMapSkill());
            foreach (Skill skill in skills)
            {
                IEnumerable<Skill> existingSkills = await _repository.Skill.GetAllSkillsAsync();
                Skill? existingSkill = existingSkills.FirstOrDefault(s => s.Name.ToLower().Equals(skill.Name.ToLower()));
                if (existingSkill is null) _repository.Skill.AddSkill(skill);
                else skill.Id = existingSkill.Id;
                   
                JobsSkills jobsSkills = new JobsSkills
                {
                    SkillId = skill.Id,
                    JobId = job.Id
                };
                _repository.JobsSkills.AddJobsSkills(jobsSkills);
            }
        }
        await _repository.SaveAsync();
        return jobDto;
    }

    public async Task<UpdateJobDto> UpdateJobAsync(Guid id, UpdateJobDto jobDto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteJobAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}