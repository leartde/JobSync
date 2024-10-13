using Contracts;
using Entities.Exceptions.AddressExceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.AddressDtos;
using Shared.Mapping;

namespace Service;

internal sealed class AddressService : IAddressService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public AddressService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task <IEnumerable<ViewAddressDto>> GetAllAddressesAsync()
    {
        IEnumerable<Address> addresses = await _repository.Address.GetAllAddressesAsync();
        IEnumerable<ViewAddressDto> addressDtos = addresses.Select(address => address.MapAddressDto());
        return addressDtos;
    }

    public async Task<ViewAddressDto> GetAddressAsync(Guid id)
    {
        Address? address = await _repository.Address.GetAddressAsync(id);
        if (address is null) throw new AddressNotFoundException(id);
        return address.MapAddressDto();
    }

    public async Task<ViewAddressDto> AddAddressAsync(AddAddressDto addressDto)
    {
        Address address = addressDto.ReverseMapAddress();
         _repository.Address.AddAddress(address);
         await _repository.SaveAsync();
         return address.MapAddressDto();
    }

    public async Task DeleteAddressAsync(Guid id)
    {
        Address? address = await _repository.Address.GetAddressAsync(id);
        if (address is null) throw new AddressNotFoundException(id);
        _repository.Address.DeleteAddress(address);
        await _repository.SaveAsync();
    }

    public async Task UpdateAddressAsync(Guid id, UpdateAddressDto addressDto)
    {
        Address? address = await _repository.Address.GetAddressAsync(id);
        if (address is null) throw new AddressNotFoundException(id);
        address = addressDto.ReverseMapAddress();
        address.Id = id;
        _repository.Address.UpdateAddress(address);
        await _repository.SaveAsync();
    }
}