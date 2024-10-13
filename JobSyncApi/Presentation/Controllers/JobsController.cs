using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.JobDtos;

namespace Presentation.Controllers;

[Route("api/jobs")]
[ApiController]
public class JobsController : ControllerBase
{
    private readonly IServiceManager _service;

    public JobsController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllJobs()
    {
        IEnumerable<ViewJobDto> jobs = await _service.JobService.GetAllJobsAsync();
        return Ok(jobs);
    }

    [HttpPost]
    public async Task<IActionResult> AddJob(AddJobDto jobDto)
    {
        await _service.JobService.AddJobAsync(jobDto);
        return Ok(jobDto);

    }
}