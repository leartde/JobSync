using Entities.Enums;
using Entities.Models;
using Shared.DataTransferObjects.EmployerDtos;

namespace Shared.Mapping;

public static class EmployerMapping
{
    public static ViewEmployerDto ToDto(this Employer entity)
    {
        return new ViewEmployerDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Email = entity.Email,
            Description = entity.Description,
            Headquarters = entity.Headquarters,
            Website = entity.Website,
            Industry = entity.IndustryString,
            Founded = entity.Founded,
            Phone = entity.Phone,
            SecondaryPhone = entity.SecondaryPhone,
            PhotoUrl = entity.PhotoUrl
        };
    }

    public static void ToEntity(this EmployerDto dto, Employer entity )
    {
        entity.UserId = dto.UserId ?? entity.UserId;
        entity.Name = dto.Name ?? entity.Name;
        entity.Email = dto.Email ?? entity.Email;
        entity.Description = dto.Description ?? entity.Description;
        entity.Headquarters = dto.Headquarters ?? entity.Headquarters;
        entity.Website = dto.Website ?? entity.Website;
        entity.Industry = (Industry)Enum.Parse(typeof(Industry), dto.Industry ?? entity.Industry.ToString()); 
        entity.Founded = dto.Founded ?? entity.Founded;
        entity.Phone = dto.Phone ?? entity.Phone;
        entity.SecondaryPhone = dto.SecondaryPhone?? entity.SecondaryPhone;
        
    }
}