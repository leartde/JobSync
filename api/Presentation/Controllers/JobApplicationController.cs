using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.JobApplicationDtos;

namespace Presentation.Controllers;
[Route("api/jobapplications")]
[ApiController]

public class JobApplicationController : ControllerBase
{
    private readonly IServiceManager _service;

    public JobApplicationController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("{jobId}/{jobSeekerId}")]
    public async Task<IActionResult> GetApplicationAsync(Guid jobId, Guid jobSeekerId)
    {
        ViewJobApplicationDto application = await _service.JobApplicationService.GetApplicationAsync(jobId, jobSeekerId);
        return Ok(application);
    }

    [HttpGet("/api/jobseekers/{jobSeekerId}/applications")]
    public async Task<IActionResult> GetApplicationsForJobSeeker(Guid jobSeekerId)
    {
        IEnumerable<ViewJobApplicationDto> applications =
            await _service.JobApplicationService.GetApplicationsForJobSeekerAsync(jobSeekerId);
        return Ok(applications);
    }
    
    
    [HttpGet("/api/employers/{employerId}/jobs/{jobId}/applications")]
    public async Task<IActionResult> GetApplicationsForJob(Guid employerId, Guid jobId)
    {
        IEnumerable<ViewJobApplicationDto> applications =
            await _service.JobApplicationService.GetApplicationsForJobAsync(employerId,jobId);
        return Ok(applications);
    }

    [HttpPost("/api/jobseekers/{jobSeekerId}/applications")]
    public async Task<IActionResult> AddApplication(Guid jobSeekerId, AddJobApplicationDto jobApplicationDto)
    {
        ViewJobApplicationDto application = await _service.JobApplicationService.AddApplicationAsync(jobSeekerId,jobApplicationDto);
        return Ok(application);
    }

}