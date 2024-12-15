// using Entities.Models;
// using Microsoft.AspNetCore.Mvc;
// using Service.Contracts;
// using Shared.DataTransferObjects.ApplicationDtos;
//
// namespace Presentation.Controllers;
// [Route("api/applications")]
// [ApiController]
//
// public class ApplicationController : ControllerBase
// {
//     private readonly IServiceManager _service;
//
//     public ApplicationController(IServiceManager service)
//     {
//         _service = service;
//     }
//
//     [HttpGet("/api/jobseekers/{jobSeekerId}/applications")]
//     public async Task<IActionResult> GetApplicationsForJobSeeker(Guid jobSeekerId)
//     {
//         IEnumerable<ViewApplicationDto> applications =
//             await _service.ApplicationService.GetApplicationsForJobSeekerAsync(jobSeekerId);
//         return Ok(applications);
//     }
//     
//     [HttpGet("/api/jobseekers/{jobSeekerId}/applications/{id}")]
//     public async Task<IActionResult> GetApplicationForJobSeeker(Guid jobSeekerId,Guid id)
//     {
//         ViewApplicationDto application =
//             await _service.ApplicationService.GetApplicationForJobSeekerAsync(jobSeekerId, id);
//         return Ok(application);
//     }
//     
//     [HttpGet("/api/employers/{employerId}/jobs/{jobId}/applications")]
//     public async Task<IActionResult> GetApplicationsForJob(Guid employerId, Guid jobId)
//     {
//         IEnumerable<ViewApplicationDto> applications =
//             await _service.ApplicationService.GetApplicationsForJobAsync(employerId,jobId);
//         return Ok(applications);
//     }
//     
//     [HttpGet("/api/employers/{employerId}/jobs/{jobId}/applications/{id}")]
//     public async Task<IActionResult> GetApplicationForJob(Guid employerId, Guid jobId,Guid id)
//     {
//         ViewApplicationDto application =
//             await _service.ApplicationService.GetApplicationForJobAsync(employerId,jobId,id);
//         return Ok(application);
//     }
//
//     [HttpPost("/api/jobseekers/{jobSeekerId}/applications")]
//     public async Task<IActionResult> AddApplication(Guid jobSeekerId, AddApplicationDto applicationDto)
//     {
//         Application application = await _service.ApplicationService.AddApplicationAsync(jobSeekerId,applicationDto);
//         return Ok(application);
//     }
//
// }