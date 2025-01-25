using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.SkillDtos;
using Shared.Mapping;

namespace Service;

public class SkillService : ISkillService
{
    private readonly IRepositoryManager _repository;

    public SkillService(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ViewSkillDto>> GetSkillsForJobAsync(Guid employerId, Guid jobId)
    {
        Job job = await _repository.Job.GetJobForEmployerAsync(employerId, jobId);
        return job.Skills.Select(s => s.ToDto());
    }

    public async Task<IEnumerable<ViewSkillDto>> GetSkillsForJobSeekerAsync(Guid jobSeekerId)
    {
        JobSeeker jobSeeker = await _repository.JobSeeker.GetJobSeekerAsync(jobSeekerId);
        return jobSeeker.Skills.Select(s => s.ToDto());
    }

    public async Task<IEnumerable<ViewSkillDto>> AddSkillsForJobAsync(Guid employerId, Guid jobId, IEnumerable<AddSkillDto> skillDtos)
    {
        Job job = await _repository.Job.GetJobForEmployerAsync(employerId, jobId);
        List<Skill> newSkills = [];
        List<Skill> existingSkills = [];
        List<JobSkill> jobSkills =[];
        foreach (AddSkillDto skillDto in skillDtos)
        {
            Skill? skill = await _repository.Skill.GetSkillByNameAsync(skillDto.Name);
            if(skill is null)
            {
                Skill newSkill = new Skill{Id = Guid.NewGuid()};
                skillDto.ToEntity(newSkill);
                newSkills.Add(newSkill);
                jobSkills.Add(new JobSkill{JobsId = job.Id,SkillsId = newSkill.Id});
            }
            else
            {
                skillDto.ToEntity(skill);
                existingSkills.Add(skill);
                jobSkills.Add(new JobSkill{JobsId = job.Id,SkillsId = skill.Id});
            }
            
        }
        if (newSkills.Count > 0)
        {
            await _repository.Skill.AddSkillsAsync(newSkills);
            await _repository.SaveAsync();
        }
        await _repository.JobSkill.AddJobSkillsAsync(jobSkills);
        await _repository.SaveAsync();
        return newSkills.Concat(existingSkills).Select(s => s.ToDto());
    }

    public async Task<IEnumerable<ViewSkillDto>> AddSkillsForJobSeekerAsync(Guid jobSeekerId, IEnumerable<AddSkillDto> skillDtos)
    {
        JobSeeker jobSeeker = await _repository.JobSeeker.GetJobSeekerAsync(jobSeekerId);
        List<Skill> newSkills = [];
        List<Skill> existingSkills = [];
        foreach (AddSkillDto skillDto in skillDtos)
        {
            Skill? skill = await _repository.Skill.GetSkillByNameAsync(skillDto.Name);
            if (skill is null)
            {
                Skill newSkill = new Skill();
                skillDto.ToEntity(newSkill);
                newSkills.Add(newSkill);
            }
            else
            {
                skillDto.ToEntity(skill);
                existingSkills.Add(skill);
            }
        }
        if (newSkills.Count > 0)
        {
            await _repository.Skill.AddSkillsAsync(newSkills);
            await _repository.SaveAsync();
        }
        List<Skill> skills = newSkills.Concat(existingSkills).ToList();
        List<JobSeekerSkill> jobSeekerSkills = skills
            .Select(skill => new JobSeekerSkill { JobSeekersId = jobSeeker.Id, SkillsId = skill.Id })
            .ToList();
        await _repository.JobSeekerSkill.AddJobSeekerSkillsAsync(jobSeekerSkills);
        await _repository.SaveAsync();
        return skills.Select(s => s.ToDto());
    }

    public async Task DeleteSkillsForJobAsync(Guid employerId, Guid jobId, List<Guid> skillIds)
    {
        Job job = await _repository.Job.GetJobForEmployerAsync(employerId, jobId);
        if (job is null) throw new NotFoundException(typeof(Job).ToString(), jobId);
        List<JobSkill> jobSkillsToDelete = skillIds
            .Select(skillId => new JobSkill { JobsId = job.Id, SkillsId = skillId })
            .ToList();
        _repository.JobSkill.DeleteJobSkills(jobSkillsToDelete);
        await _repository.SaveAsync();
    }

    public async Task DeleteSkillsForJobSeekerAsync(Guid jobSeekerId, List<Guid> skillIds)
    {
        JobSeeker jobSeeker = await _repository.JobSeeker.GetJobSeekerAsync(jobSeekerId);
        if (jobSeeker is null) throw new NotFoundException(typeof(JobSeeker).ToString(), jobSeekerId);
        List<JobSeekerSkill> jobSeekerSkillsToDelete = skillIds
            .Select(skillId => new JobSeekerSkill { JobSeekersId = jobSeeker.Id, SkillsId = skillId })
            .ToList();
      _repository.JobSeekerSkill.DeleteJobSeekerSkills(jobSeekerSkillsToDelete);
      await _repository.SaveAsync();

    }
}