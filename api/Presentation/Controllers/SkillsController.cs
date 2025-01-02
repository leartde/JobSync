using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.SkillDtos;

namespace Presentation.Controllers;

[ApiController]
public class SkillsController : ControllerBase
{
    private readonly IServiceManager _service;

    public SkillsController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("/api/employers/{employerId}/jobs/{jobId}/skills")]
    public async Task<IActionResult> GetSkillsForJob(Guid employerId, Guid jobId)
    {
        IEnumerable<ViewSkillDto> skills = await _service.SkillService
            .GetSkillsForJobAsync(employerId, jobId);
        return Ok(skills);
    }

    [HttpGet("/api/jobseekers/{jobSeekerId}/skills")]
    public async Task<IActionResult> GetSkillsForJobSeeker(Guid jobSeekerId)
    {
        IEnumerable<ViewSkillDto> skills = await _service.SkillService
            .GetSkillsForJobSeekerAsync(jobSeekerId);
        return Ok(skills);
    }


    [HttpPost("/api/employers/{employerId}/jobs/{jobId}/skills")]
    public async Task<IActionResult> AddSkillsForJob(Guid employerId, Guid jobId, IEnumerable<AddSkillDto> skillDtos)
    {
        IEnumerable<ViewSkillDto> skills =
            await _service.SkillService.AddSkillsForJobAsync(employerId, jobId, skillDtos);
        return Ok(skills);
    }
    
    [HttpPost("/api/jobseekers/{jobSeekerId}/skills")]
    public async Task<IActionResult> AddSkillsForJobSeeker(Guid jobSeekerId, IEnumerable<AddSkillDto> skillDtos)
    {
        IEnumerable<ViewSkillDto> skills =
            await _service.SkillService.AddSkillsForJobSeekerAsync(jobSeekerId,skillDtos);
        return Ok(skills);
    }
    
    [HttpDelete("/api/employers/{employerId}/jobs/{jobId}/skills")]
    public async Task<IActionResult> DeleteSkillsForJob(Guid employerId, Guid jobId, List<Guid> skillIds)
    {
        await _service.SkillService.DeleteSkillsForJobAsync(employerId, jobId, skillIds);
        return Ok("Skills for this job successfully deleted");
    }

    [HttpDelete("/api/jobseekers/{jobSeekerId}/skills")]
    public async Task<IActionResult> DeleteSkillsForJobSeeker(Guid jobSeekerId, List<Guid> skillIds)
    {
        await _service.SkillService.DeleteSkillsForJobSeekerAsync(jobSeekerId, skillIds);
        return Ok("Skills for this job seeker successfully deleted");
    }

    
}