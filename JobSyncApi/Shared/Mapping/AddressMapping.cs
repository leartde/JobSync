using Entities.Exceptions;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Shared.Mapping;

public static class AddressMapping
{
    public static AddressDto MapAddressDto(this Address? entity)
    {
        if (entity is null) throw new MappingException("address");
        return new AddressDto
        {
            Id = entity.Id,
            Country = entity.Country,
            City = entity.City,
            State = entity.State,
            Region = entity.Region,
            Street = entity.Street,
            ZipCode = entity.ZipCode
        };
    }

    public static Address ReverseMapAddress(this AddAddressDto? entity)
    {
        if (entity is null) throw new MappingException("address");
        return new Address
        {
            Country = entity.Country,
            State = entity.State,
            City = entity.City,
            Region = entity.Region,
            Street = entity.Street,
            ZipCode = entity.ZipCode
        };
    }
}