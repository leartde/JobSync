using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.JobDtos;

namespace Presentation.Controllers;

[Route("api/employers/{employerId}/jobs")]
[ApiController]
public class JobsController : ControllerBase
{
    private readonly IServiceManager _service;

    public JobsController(IServiceManager service)
    {
        _service = service;
    }

    // [HttpGet]
    // public async Task<IActionResult> GetAllJobs()
    // {
    //     IEnumerable<ViewJobDto> jobs = await _service.JobService.GetAllJobsAsync();
    //     return Ok(jobs);
    // }

    [HttpGet]
    public async Task<IActionResult> GetJobsForEmployer(Guid employerId)
    {
        IEnumerable<ViewJobDto> jobs = await _service.JobService.GetJobsForEmployerAsync(employerId);
        return Ok(jobs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetJobForEmployer(Guid employerId, Guid id)
    {
        ViewJobDto job = await _service.JobService.GetJobForEmployerAsync(employerId, id);
        return Ok(job);
    }

    [HttpPost]
    public async Task<IActionResult> AddJob(Guid employerId,AddJobDto jobDto)
    {
        await _service.JobService.AddJobForEmployerAsync(employerId,jobDto);
        return Ok(jobDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateJob(Guid employerId, Guid id, UpdateJobDto jobDto)
    {
        await _service.JobService.UpdateJobForEmployerAsync(employerId, id, jobDto);
        return Ok(jobDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJobForEmployer(Guid employerId,Guid id)
    {
        await _service.JobService.DeleteJobForEmployerAsync(employerId,id);
        return Ok();
    }
}