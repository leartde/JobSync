using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.AddressDtos;

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
        IEnumerable<ViewAddressDto> addresses = await _service.AddressService.GetAllAddressesAsync();
        return Ok(addresses);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAddress(Guid id)
    {
        ViewAddressDto viewAddress = await _service.AddressService.GetAddressAsync(id);
        return Ok(viewAddress);
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
    public async Task<IActionResult> UpdateAddress(Guid id, UpdateAddressDto addressDto)
    {
        await _service.AddressService.UpdateAddressAsync(id, addressDto);
        return Ok();
    }
    
}