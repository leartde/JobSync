using Entities.Models;
using Shared.DataTransferObjects.EmployerDtos;

namespace Shared.Mapping;

public static class EmployerMapping
{
    public static ViewEmployerDto? MapEmployerDto(this Employer entity)
    {
        return new ViewEmployerDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Country = entity.Country,
            Industry = entity.Industry,
            Founded = entity.Founded,
            Phone = entity.Phone,
            SecondaryPhone = entity.SecondaryPhone,
            
        };
    }

    public static void ReverseMapEmployer(this EmployerDto dto, Employer entity )
    {
        entity.UserId = dto.UserId ?? entity.UserId;
        entity.Name = dto.Name ?? entity.Name;
        entity.Country = dto.Country ?? entity.Country;
        entity.Industry = dto.Industry ?? entity.Industry;
        entity.Founded = dto.Founded ?? entity.Founded;
        entity.Phone = dto.Phone ?? entity.Phone;
        entity.SecondaryPhone = dto.SecondaryPhone?? entity.SecondaryPhone;
        
    }
}