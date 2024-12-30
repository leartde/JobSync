using System.Diagnostics;
using CloudinaryDotNet.Actions;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.AddressDtos;
using Shared.DataTransferObjects.JobSeekerDtos;
using Shared.DataTransferObjects.SkillDtos;
using Shared.Mapping;

namespace Service;

internal sealed class JobSeekerService : IJobSeekerService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly ICloudinaryManager _cloudinaryManager;
    

    public JobSeekerService(IRepositoryManager repository, ILoggerManager logger, ICloudinaryManager cloudinaryManager)
    {
        _repository = repository;
        _logger = logger;
        _cloudinaryManager = cloudinaryManager;
    }
    public async Task<IEnumerable<ViewJobSeekerDto>> GetAllJobSeekersAsync()
    {
        IEnumerable<JobSeeker> jobSeekers = await _repository.JobSeeker.GetAllJobSeekersAsync();
        return jobSeekers.Select(js => js.ToDto());
    }

    public async Task<ViewJobSeekerDto> GetJobSeekerAsync(Guid id)
    {
        JobSeeker jobSeeker = await RetrieveJobSeekerAsync(id);
        return jobSeeker.ToDto();
    }
    
    
    public async Task<ViewJobSeekerDto> AddJobSeekerAsync(AddJobSeekerDto jobSeekerDto)
    {
        
        JobSeeker jobSeeker = new JobSeeker();
        jobSeekerDto.ToEntity(jobSeeker);
        if (jobSeekerDto.Resume != null)
        {
            UploadResult result = await _cloudinaryManager.RawUploader.AddFileAsync(jobSeekerDto.Resume);
            jobSeeker.ResumeLink = result.Url.ToString();
        }
        await _repository.JobSeeker.AddJobSeekerAsync(jobSeeker);
        if (jobSeekerDto.Skills != null)
        {
            await AddSkillsForJobSeekerAsync(jobSeeker, jobSeekerDto.Skills);
        }

        await _repository.SaveAsync();
        return jobSeeker.ToDto();
    }
    
    public async Task DeleteJobSeekerAsync(Guid id)
    {
        JobSeeker jobSeeker = await RetrieveJobSeekerAsync(id);
        _repository.JobSeeker.DeleteJobSeeker(jobSeeker);
        await _repository.SaveAsync();

    }

    public async Task<ViewJobSeekerDto> UpdateJobSeekerAsync(Guid id, UpdateJobSeekerDto jobSeekerDto)
    {
        JobSeeker jobSeeker = await RetrieveJobSeekerAsync(id);
        jobSeekerDto.ToEntity(jobSeeker);
         _repository.JobSeeker.UpdateJobSeeker(jobSeeker);
         await _repository.SaveAsync();
         return jobSeeker.ToDto();

    }

    private async Task<JobSeeker> RetrieveJobSeekerAsync(Guid id)
    {
        JobSeeker? jobSeeker = await _repository.JobSeeker.GetJobSeekerAsync(id);
        if (jobSeeker is null) throw new NotFoundException("jobSeeker",id);
        return jobSeeker;
    }
    private async Task AddSkillsForJobSeekerAsync(JobSeeker jobSeeker, List<AddSkillDto> skillDtos)
    {
        List<Skill> newSkills = [];
        List<JobSeekerSkill> jobSeekerSkills = [];
        foreach (AddSkillDto skillDto in skillDtos)
        {
            Skill? skill = await _repository.Skill.GetSkillByNameAsync(skillDto.Name);
            if (skill is null)
            {
                Skill newSkill = new Skill { Id = Guid.NewGuid() };
                skillDto.ToEntity(newSkill);
                newSkills.Add(newSkill);
                jobSeekerSkills.Add(new JobSeekerSkill { JobSeekersId = jobSeeker.Id, SkillsId = newSkill.Id });
            }
            else
            {
                skillDto.ToEntity(skill);
                jobSeekerSkills.Add(new JobSeekerSkill { JobSeekersId = jobSeeker.Id, SkillsId = skill.Id });
            }

            if (newSkills.Count > 0)
            {
                await _repository.Skill.AddSkillsAsync(newSkills);
                await _repository.SaveAsync();
            }
            await _repository.JobSeekerSkill.AddJobSeekerSkillsAsync(jobSeekerSkills);


        }
    }
}