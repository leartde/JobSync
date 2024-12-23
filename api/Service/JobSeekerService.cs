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
        if (jobSeekerDto.Address != null)
        {
            await AddAddressForJobSeekerAsync(jobSeeker,jobSeekerDto.Address);
        }
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
    
    private async Task AddAddressForJobSeekerAsync(JobSeeker jobSeeker, AddAddressDto addressDto)
    {
        Address address = new Address();
        addressDto.ToEntity(address);
        await _repository.Address.AddAddressAsync(address);
        await _repository.SaveAsync();
        jobSeeker.AddressId = address.Id;
    }

    private async Task AddSkillsForJobSeekerAsync(JobSeeker jobSeeker, List<AddSkillDto> skillDtos)
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
                _repository.JobSeekerSkill.AddJobSeekerSkill(new JobSeekerSkill
                    { SkillsId = newSkill.Id, JobSeekersId = jobSeeker.Id });
            }
        }

        foreach (Skill existingSkill in existingSkills)
        {
            _repository.JobSeekerSkill.AddJobSeekerSkill(new JobSeekerSkill
                { SkillsId = existingSkill.Id, JobSeekersId = jobSeeker.Id });
        }

    }
}