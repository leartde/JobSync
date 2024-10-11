using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.EmployerDtos;

namespace Presentation.Controllers;

[Route("api/employers")]
[ApiController]
public class EmployersController : ControllerBase
{
    private readonly IServiceManager _service;

    public EmployersController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployers()
    {
        IEnumerable<EmployerDto> employers = await _service.EmployerService.GetAllEmployersAsync();
        return Ok(employers);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployer(AddEmployerDto employer)
    {
        await _service.EmployerService.CreateEmployerAsync(employer);
        return Ok(employer);
    }
}