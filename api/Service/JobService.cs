using System.ComponentModel;
using System.Dynamic;
using CloudinaryDotNet.Actions;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Service.Contracts;
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
    private readonly IImageUploader _imageUploader;

    public JobService(IRepositoryManager repository, ILoggerManager logger, IDataShaper<ViewJobDto> dataShaper, IImageUploader imageUploader )
    {
        _repository = repository;
        _logger = logger;
        _dataShaper = dataShaper;
        _imageUploader = imageUploader;
    }

    public async Task<(IEnumerable<ExpandoObject> jobs,MetaData metaData)> GetAllJobsAsync(JobParameters jobParameters)
    {
        
        PagedList<Job> jobs = await _repository.Job.GetAllJobsAsync(jobParameters);
        IEnumerable<ViewJobDto> jobDtos = jobs.Select(j => j.MapJobDto());
        IEnumerable<ExpandoObject> shapedData = _dataShaper.ShapeData(jobDtos, jobParameters.Fields);
        return (jobs: shapedData, metaData: jobs.MetaData);
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

    public async Task<Job> AddJobForEmployerAsync(Guid employerId,AddJobDto jobDto)
    {
        Job job = new Job
        {
            EmployerId = employerId
        };
        if (jobDto.Address != null) 
        {
            Address address = new Address();
            jobDto.Address.ReverseMapAddress(address);
            _repository.Address.AddAddress(address);
            await _repository.SaveAsync();
            job.AddressId = address.Id;
        }
        jobDto.ReverseMapJob(job);
        if (jobDto.Image != null)
        {
            ImageUploadResult result = await _imageUploader.AddPhotoAsync(jobDto.Image);
            job.ImageUrl = result.Url.ToString();
        }
        _repository.Job.AddJob(job);
        if (jobDto.Skills != null)
        {
            List<Skill> skills = [];
            
            foreach (AddSkillDto skillDto in jobDto.Skills)
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
        return job; 
        }
    

    public async Task<ViewJobDto> UpdateJobForEmployerAsync(Guid employerId, Guid id, UpdateJobDto jobDto)
    {
        Job job = await RetrieveJobForEmployerAsync(employerId, id);
        jobDto.ReverseMapJob(job);
        _repository.Job.UpdateJob(job);
        await _repository.SaveAsync();
        return job.MapJobDto();
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