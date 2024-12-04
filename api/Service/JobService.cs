using System.ComponentModel;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using JobSync.Helpers;
using Service.Contracts;
using Shared.DataTransferObjects.JobDtos;
using Shared.DataTransferObjects.SkillDtos;
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
    
    public async Task<IEnumerable<ViewJobDto>> GetJobsForEmployerAsync(Guid employerId)
    {
        
        IEnumerable<Job> jobs = await _repository.Job.GetJobsForEmployerAsync(employerId);
        return jobs.Select(j => j.MapJobDto());
    }

    public async Task<ViewJobDto> GetJobForEmployerAsync(Guid employerId,Guid id)
    {
        
        Job job = await RetrieveJobForEmployerAsync(employerId,id);
        return  job.MapJobDto();
    }

    public async Task<AddJobDto> AddJobForEmployerAsync(Guid employerId,AddJobDto jobDto)
    {
        Address address = new Address();
        jobDto.Address?.ReverseMapAddress(address);
        _repository.Address.AddAddress(address);
        await _repository.SaveAsync();
        Job job = new Job
        {
            AddressId = address.Id,
            EmployerId = employerId
        };
        jobDto.ReverseMapJob(job);
        _repository.Job.AddJob(job);
        if (jobDto.Skills != null)
        {
            List<Skill> skills = [];
            
            foreach (SkillDto skillDto in jobDto.Skills)
            {
                Skill skill = new Skill();
                skillDto.ReverseMapSkill(skill);
                skills.Add(skill);
            }
            
            foreach (Skill skill in skills)
            {
                IEnumerable<Skill> existingSkills = await _repository.Skill.GetAllSkillsAsync();
                Skill? existingSkill = existingSkills.FirstOrDefault(s => s.Name.ToLower().Equals(skill.Name.ToLower()));
                JobSkill jobSkill = new JobSkill
                {
                    JobsId = job.Id
                };

                if (existingSkill != null) jobSkill.SkillsId = existingSkill.Id;
                _repository.Skill.AddSkill(skill);
                await _repository.SaveAsync();
                jobSkill.SkillsId = skill.Id;
 
                _repository.JobSkill.AddJobSkill(jobSkill);
            }
        }
        await _repository.SaveAsync();
        return jobDto; 
        }
    

    public async Task<UpdateJobDto> UpdateJobForEmployerAsync(Guid employerId, Guid id, UpdateJobDto jobDto)
    {
        Job job = await RetrieveJobForEmployerAsync(employerId, id);
        jobDto.ReverseMapJob(job);
        _repository.Job.UpdateJob(job);
        await _repository.SaveAsync();
        return jobDto;
    }

    public async Task DeleteJobForEmployerAsync(Guid employerId,Guid id)
    {
        Job? job = await RetrieveJobForEmployerAsync(employerId, id);
        if (job is null) throw new NotFoundException("job",id);
        _repository.Job.DeleteJob(job);
        await _repository.SaveAsync();
    }

    private async Task<Job> RetrieveJobForEmployerAsync(Guid employerId, Guid id)
    {
        Job? job = await _repository.Job.GetJobForEmployerAsync(employerId,id);
        if (job is null) throw new NotFoundException("job",id);
        return job;
    }
}