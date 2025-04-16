using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.UserDtos;

namespace Presentation.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _service;

    public AuthenticationController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpPost("register/jobseeker")]
    public async Task<IActionResult> RegisterUser([FromForm] RegisterJobSeekerDto userDto)
    {
         (IdentityResult result,AppUser user) = await _service.AuthenticationService.RegisterUser(userDto);
        if (result.Succeeded)
        {
            if (userDto.AddJobSeekerDto is null)
            {
                throw new BadRequestException("Job Seeker details are missing");
            }
            userDto.AddJobSeekerDto.UserId = user.Id;
            await _service.JobSeekerService.AddJobSeekerAsync(userDto.AddJobSeekerDto);
            return StatusCode(201);
        }
        foreach (IdentityError error in result.Errors)
        {
            ModelState.TryAddModelError(error.Code, error.Description);
        }
        return BadRequest(ModelState);
    }

    [HttpPost("register/employer")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterEmployerDto userDto)
    {
        (IdentityResult result, AppUser user) = await _service.AuthenticationService.RegisterUser(userDto);
        if (result.Succeeded)
        {
            if (userDto.AddEmployerDto is null)
            {
                throw new BadRequestException("Employer details are missing");
            }

            userDto.AddEmployerDto.UserId = user.Id;
            await _service.EmployerService.AddEmployerAsync(userDto.AddEmployerDto);
            return StatusCode(201);
        }

        foreach (IdentityError error in result.Errors)
        {
            ModelState.TryAddModelError(error.Code, error.Description);
        }

        return BadRequest(ModelState);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Authenticate([FromBody] LoginUserDto userDto)
    {
        if (!await _service.AuthenticationService.ValidateUser(userDto)) return Unauthorized();
        return Ok(new { Token = await _service.AuthenticationService.CreateToken() });
    }
}