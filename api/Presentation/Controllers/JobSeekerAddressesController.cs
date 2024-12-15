using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.AddressDtos;

namespace Presentation.Controllers;
[Route("api/jobseekers/{jobSeekerId}/address")]

public class JobSeekerAddressesController : ControllerBase
{
    private readonly IServiceManager _service;

    public JobSeekerAddressesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAddress(Guid jobSeekerId)
    {
        ViewAddressDto address = await _service.AddressService.GetAddressForJobSeekerAsync(jobSeekerId);
        return Ok(address);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAddress(Guid jobSeekerId,AddAddressDto addressDto)
    {
        Address address = await _service.AddressService.AddAddressForJobSeekerAsync(jobSeekerId, addressDto);
        return Ok(address);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAddress(Guid jobSeekerId,UpdateAddressDto addressDto)
    {
        ViewAddressDto address = await _service.AddressService.UpdateAddressForJobSeekerAsync(jobSeekerId, addressDto);
        return Ok(address);
    }
    
    [HttpDelete]
    public async Task<IActionResult> UpdateAddress(Guid jobSeekerId)
    {
        await _service.AddressService.DeleteAddressForJobSeekerAsync(jobSeekerId);
        return Ok();
    }
    
    
    
    
    

}