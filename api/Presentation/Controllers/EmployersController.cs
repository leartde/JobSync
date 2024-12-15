﻿using Entities.Models;
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
        IEnumerable<ViewEmployerDto> employers = await _service.EmployerService.GetAllEmployersAsync();
        return Ok(employers);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployer(AddEmployerDto employerDto)
    {
        ViewEmployerDto employer = await _service.EmployerService.AddEmployerAsync(employerDto);
        return Ok(employer);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployer(Guid id)
    {
        ViewEmployerDto? viewEmployer = await _service.EmployerService.GetEmployerAsync(id);
        return Ok(viewEmployer);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployer(Guid id, UpdateEmployerDto employerDto)
    {
        ViewEmployerDto employer = await _service.EmployerService.UpdateEmployerAsync(id, employerDto);
        return Ok(employer);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployer(Guid id)
    {
        await _service.EmployerService.DeleteEmployerAsync(id);
        return Ok();
    }
}