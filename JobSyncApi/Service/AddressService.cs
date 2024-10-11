using Contracts;
using Entities.Exceptions.AddressExceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
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


    public async Task <IEnumerable<AddressDto>> GetAllAddressesAsync()
    {
        IEnumerable<Address> addresses = await _repository.Address.GetAllAddressesAsync();
        List<AddressDto> addressesDto = [];
        addressesDto.AddRange(addresses.Select(address => address.MapAddressDto()));
        return addressesDto;
    }

    public async Task<AddressDto> GetAddressAsync(Guid id)
    {
        Address? address = await _repository.Address.GetAddressAsync(id);
        if (address is null) throw new AddressNotFoundException(id);
        return address.MapAddressDto();
    }

    public async Task<AddressDto> AddAddressAsync(AddAddressDto addressDto)
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

    public async Task UpdateAddressAsync(Guid id, AddAddressDto addressDto)
    {
        Address? address = await _repository.Address.GetAddressAsync(id);
        if (address is null) throw new AddressNotFoundException(id);
        address = addressDto.ReverseMapAddress();
        address.Id = id;
        _repository.Address.UpdateAddress(address);
        await _repository.SaveAsync();
    }
}