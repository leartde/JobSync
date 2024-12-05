using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.AddressDtos;

namespace Presentation.Controllers;

[Route("api/employers/{employerId}/jobs/{jobId}/address")]
[ApiController]
public class JobAddressesController : ControllerBase
{
    private readonly IServiceManager _service;

    public JobAddressesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAddress(Guid employerId, Guid jobId)
    {
        ViewAddressDto addresses = await _service.AddressService.GetAddressForJobAsync(employerId,jobId);
        return Ok(addresses);
    }
    [HttpPost]
    public async Task<IActionResult> AddAddress(Guid employerId, Guid jobId,AddAddressDto addressDto)
    {
        await _service.AddressService.AddAddressForJobAsync(employerId,jobId,addressDto);
        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteAddress(Guid employerId, Guid jobId)
    {
        await _service.AddressService.DeleteAddressForJobAsync( employerId,jobId);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAddress(Guid employerId, Guid jobId, UpdateAddressDto addressDto)
    {
        await _service.AddressService.UpdateAddressForJobAsync(employerId,jobId, addressDto);
        return Ok();
    }
    
}