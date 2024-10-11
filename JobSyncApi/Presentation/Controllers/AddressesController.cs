using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Presentation.Controllers;

[Route("api/addresses")]
[ApiController]
public class AddressesController : ControllerBase
{
    private readonly IServiceManager _service;

    public AddressesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAddresses()
    {
        IEnumerable<AddressDto> addresses = await _service.AddressService.GetAllAddressesAsync();
        return Ok(addresses);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAddress(Guid id)
    {
        AddressDto address = await _service.AddressService.GetAddressAsync(id);
        return Ok(address);
    }

    [HttpPost]
    public async Task<IActionResult> AddAddress(AddAddressDto addressDto)
    {
        await _service.AddressService.AddAddressAsync(addressDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAddress(Guid id)
    {
        await _service.AddressService.DeleteAddressAsync(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAddress(Guid id, AddAddressDto addressDto)
    {
        await _service.AddressService.UpdateAddressAsync(id, addressDto);
        return Ok();
    }
    
}