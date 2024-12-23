using System.Dynamic;
using CloudinaryDotNet.Actions;
using Contracts;
using Entities.Enums;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.AddressDtos;
using Shared.DataTransferObjects.JobDtos;
using Shared.DataTransferObjects.SkillDtos;
using Shared.Mapping;
using Shared.RequestFeatures;

namespace Service;

internal sealed class JobService : IJobService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IDataShaper<ViewJobDto> _dataShaper;
    private readonly ICloudinaryManager _cloudinaryManager;

    public JobService(IRepositoryManager repository, ILoggerManager logger, IDataShaper<ViewJobDto> dataShaper, ICloudinaryManager cloudinaryManager )
    {
        _repository = repository;
        _logger = logger;
        _dataShaper = dataShaper;
        _cloudinaryManager = cloudinaryManager;
    }

    public async Task<(IEnumerable<ExpandoObject> jobs, MetaData metaData)> GetAllJobsAsync(JobParameters jobParameters)
    {
        PagedList<Job> jobs = await _repository.Job.GetAllJobsAsync(jobParameters);
        IEnumerable<ExpandoObject> shapedData = 
        _dataShaper.ShapeData(jobs.Select(j => j.ToDto()), jobParameters.Fields);
        return (jobs: shapedData, metaData: jobs.MetaData);
    }
    
    public async Task<IEnumerable<ViewJobDto>> GetJobsForEmployerAsync(Guid employerId)
    {
        IEnumerable<Job> jobs = await _repository.Job.GetJobsForEmployerAsync(employerId);
        return jobs.Select(j => j.ToDto());
    }

    public async Task<ViewJobDto> GetJobForEmployerAsync(Guid employerId,Guid id)
    {
        Job job = await RetrieveJobForEmployerAsync(employerId,id);
        return job.ToDto();
    }

    public async Task<ViewJobDto> AddJobForEmployerAsync(Guid employerId,AddJobDto jobDto)
    {
        Job job = new Job
        {
            EmployerId = employerId
        };
        if (jobDto.Address != null)
        {
            await AddAddressForJobAsync(job, jobDto.Address);
        }
        jobDto.ToEntity(job);
        if (jobDto.Image != null)
        {
            ImageUploadResult result = await _cloudinaryManager.ImageUploader.AddPhotoAsync(jobDto.Image);
            job.ImageUrl = result.Url.ToString();
        }
        await _repository.Job.AddJobAsync(job);
        if (jobDto.Skills?.Count > 0 )
        {
            await AddSkillsForJobAsync(job, jobDto.Skills);
        }

        if (jobDto.Benefits?.Count() > 0)
        {
            await AddBenefitsForJobAsync(job, jobDto.Benefits);
        }
        await _repository.SaveAsync();
        return job.ToDto(); 
        }
    
    public async Task<ViewJobDto> UpdateJobForEmployerAsync(Guid employerId, Guid id, UpdateJobDto jobDto)
    {
        Job job = await RetrieveJobForEmployerAsync(employerId, id);
        jobDto.ToEntity(job);
        _repository.Job.UpdateJob(job);
        await _repository.SaveAsync();
        return job.ToDto();
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

    private async Task AddAddressForJobAsync(Job job, AddAddressDto addressDto)
    {
        Address address = new Address();
        addressDto.ToEntity(address);
        await _repository.Address.AddAddressAsync(address);
        await _repository.SaveAsync();
        job.AddressId = address.Id;
    }


    private async Task AddSkillsForJobAsync(Job job, List<AddSkillDto> skillDtos)
    {
        List<Skill> existingSkills = [];
        List<Skill> newSkills = [];
        foreach (AddSkillDto skillDto in skillDtos)
        {
            Skill? skill = await _repository.Skill.GetSkillByNameAsync(skillDto.Name);
            if (skill != null) existingSkills.Add(skill);
            else
            {
                Skill newSkill = new Skill();
                skillDto.ToEntity(newSkill);
                newSkills.Add(newSkill);
            }
        }
        if (newSkills.Count > 0)
        {
            _repository.Skill.AddSkills(newSkills);
            await _repository.SaveAsync();
            foreach (Skill newSkill in newSkills)
            {
                _repository.JobSkill.AddJobSkill(new JobSkill { SkillsId = newSkill.Id, JobsId = job.Id });
            }
        }
        
        foreach (Skill existingSkill in existingSkills)
        {
            _repository.JobSkill.AddJobSkill(new JobSkill { SkillsId = existingSkill.Id, JobsId = job.Id });
        }
    }

    private async Task AddBenefitsForJobAsync(Job job, IEnumerable<string> benefitNames)
    {
        List<JobBenefit> benefits = [];
            foreach (string benefitName in benefitNames)
            {
                JobBenefit jobBenefit = new JobBenefit
                {
                    Benefit = (Benefit)Enum.Parse(typeof(Benefit), benefitName),
                    JobId = job.Id
                };
                benefits.Add(jobBenefit);
            }
           await  _repository.JobBenefit.AddBenefitsAsync(benefits);
    }

}