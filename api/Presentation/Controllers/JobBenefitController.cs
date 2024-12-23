using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.JobBenefitDtos;

namespace Presentation.Controllers;

[ApiController]
[Route("/api/employers/{employerId}/jobs/{jobId}/benefits")]
public class JobBenefitController : ControllerBase
{
    private readonly IServiceManager _service;

    public JobBenefitController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetBenefitsForJob(Guid employerId, Guid jobId)
    {
        IEnumerable<ViewJobBenefitDto> benefits =
            await _service.JobBenefitService.GetBenefitsForJobAsync(employerId, jobId);
        return Ok(benefits);
    }

    [HttpPost]
    public async Task<IActionResult> AddBenefitsForJob(Guid employerId, Guid jobId,
        IEnumerable<AddJobBenefitDto> benefitDtos)
    {
        IEnumerable<ViewJobBenefitDto> benefits =
            await _service.JobBenefitService.AddBenefitsForJobAsync(employerId, jobId, benefitDtos);
        return Ok(benefits);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBenefitsForJob(Guid employerId, Guid jobId,
        IEnumerable<ViewJobBenefitDto> benefitDtos)
    {
        await _service.JobBenefitService.DeleteBenefitsForJobAsync(employerId, jobId, benefitDtos);
        return Ok();
    }
}