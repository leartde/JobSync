using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.JobSeekerDtos;

namespace Presentation.Controllers;

[ApiController]
[Route("api/jobseekers")]
public class JobSeekersController : ControllerBase
{
    private readonly IServiceManager _service;

    public JobSeekersController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllJobSeekers()
    {
        IEnumerable<ViewJobSeekerDto> jobSeekers = await _service.JobSeekerService.GetAllJobSeekersAsync();
        return Ok(jobSeekers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetJobSeeker(Guid id)
    {
        ViewJobSeekerDto jobSeeker = await _service.JobSeekerService.GetJobSeekerAsync(id);
        return Ok(jobSeeker);

    }

    [HttpPost]
    public async Task<IActionResult> AddJobSeeker([FromForm]AddJobSeekerDto jobSeekerDto)
    {
       ViewJobSeekerDto jobSeeker =  await _service.JobSeekerService.AddJobSeekerAsync(jobSeekerDto);
        return Ok(jobSeeker);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateJobSeeker(Guid id, UpdateJobSeekerDto jobSeekerDto)
    {
        ViewJobSeekerDto jobSeeker = await _service.JobSeekerService.UpdateJobSeekerAsync(id, jobSeekerDto);
        return Ok(jobSeeker);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJobSeeker(Guid id)
    {
        await _service.JobSeekerService.DeleteJobSeekerAsync(id);
        return Ok();

    }

   
    
}