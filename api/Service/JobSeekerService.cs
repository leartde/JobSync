using System.Diagnostics;
using CloudinaryDotNet.Actions;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.JobSeekerDtos;
using Shared.DataTransferObjects.SkillDtos;
using Shared.Mapping;

namespace Service;

internal sealed class JobSeekerService : IJobSeekerService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IPdfUploader _pdfUploader;
    

    public JobSeekerService(IRepositoryManager repository, ILoggerManager logger, IPdfUploader pdfUploader)
    {
        _repository = repository;
        _logger = logger;
        _pdfUploader = pdfUploader;
    }
    public async Task<IEnumerable<ViewJobSeekerDto>> GetAllJobSeekersAsync()
    {
        IEnumerable<JobSeeker> jobSeekers = await _repository.JobSeeker.GetAllJobSeekersAsync();
        return jobSeekers.Select(js => js.MapJobSeekerDto());
    }

    public async Task<ViewJobSeekerDto> GetJobSeekerAsync(Guid id)
    {
        JobSeeker jobSeeker = await RetrieveJobSeekerAsync(id);
        return jobSeeker.MapJobSeekerDto();
    }
    
    

    public async Task<ViewJobSeekerDto> AddJobSeekerAsync(AddJobSeekerDto jobSeekerDto)
    {
        Address address = new Address();
        jobSeekerDto.Address?.ReverseMapAddress(address);
        _repository.Address.AddAddress(address);
        await _repository.SaveAsync();
        JobSeeker jobSeeker = new JobSeeker
        {
            AddressId = address.Id
        };
        jobSeekerDto.ReverseMapJobSeeker(jobSeeker);
        if (jobSeekerDto.Resume != null)
        {
            UploadResult result = await _pdfUploader.AddPdfAsync(jobSeekerDto.Resume);
            jobSeeker.ResumeLink = result.Url.ToString();
        }
        _repository.JobSeeker.AddJobSeeker(jobSeeker);
        if (jobSeekerDto.Skills != null)
        {
            List<Skill> skills = [];
            foreach (SkillDto skillDto in jobSeekerDto.Skills)
            {
                Skill skill = new Skill();
                skillDto.ReverseMapSkill(skill);
                skills.Add(skill);
            }
            foreach (Skill skill in skills)
            {
                IEnumerable<Skill> existingSkills = await _repository.Skill.GetAllSkillsAsync();
                Skill? existingSkill = existingSkills.FirstOrDefault(s => s.Name.ToLower().Equals(skill.Name.ToLower()));
                JobSeekerSkill jobSeekerSkill = new JobSeekerSkill
                {
                    JobSeekersId = jobSeeker.Id
                };
                if (existingSkill != null) jobSeekerSkill.SkillsId = existingSkill.Id;
                _repository.Skill.AddSkill(skill);
                await _repository.SaveAsync();
                jobSeekerSkill.SkillsId = skill.Id;
                    _repository.JobSeekerSkill.AddJobSeekerSkill(jobSeekerSkill);
            }
        }

        await _repository.SaveAsync();
        return jobSeeker.MapJobSeekerDto();
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
        jobSeekerDto.ReverseMapJobSeeker(jobSeeker);
         _repository.JobSeeker.UpdateJobSeeker(jobSeeker);
         await _repository.SaveAsync();
         return jobSeeker.MapJobSeekerDto();

    }

    private async Task<JobSeeker> RetrieveJobSeekerAsync(Guid id)
    {
        JobSeeker? jobSeeker = await _repository.JobSeeker.GetJobSeekerAsync(id);
        if (jobSeeker is null) throw new NotFoundException("jobSeeker",id);
        return jobSeeker;
    }
}