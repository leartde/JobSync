using System.Reflection.Metadata;
using Entities.Exceptions;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.AddressDtos;

namespace Shared.Mapping;

public static class AddressMapping
{
    public static ViewAddressDto ToDto(this Address? entity)
    {
        if (entity is null) throw new MappingException("address");
        return new ViewAddressDto
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

    public static void ToEntity(this AddressDto dto, Address entity)
    {
       
        if (dto == null )
            throw new ArgumentNullException(nameof(dto), "AddressDto is null");
        entity.Country = dto.Country??entity.Country;
        entity.State = dto.State??entity.State;
        entity.City = dto.City??entity.City;
        entity.Region = dto.Region??entity.Region;
        entity.Street = dto.Street??entity.Street;
        entity.ZipCode = dto.ZipCode??entity.ZipCode;

        
    }
   
}