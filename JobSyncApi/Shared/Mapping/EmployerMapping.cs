using Entities.Models;
using Shared.DataTransferObjects.EmployerDtos;

namespace Shared.Mapping;

public static class EmployerMapping
{
    public static ViewEmployerDto MapEmployerDto(this Employer entity)
    {
        return new ViewEmployerDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Industry = entity.Industry,
            Founded = entity.Founded,
            Phone = entity.Phone,
            SecondaryPhone = entity.SecondaryPhone,
            Address = entity.Address.MapAddressDto()
        };
    }

    public static Employer ReverseMapEmployer(this EmployerDto entity)
    {
        return new Employer
        {
            Name = entity.Name, 
            Industry = entity.Industry,
            Founded = entity.Founded,
            Phone = entity.Phone,
            SecondaryPhone = entity.SecondaryPhone,
            Address = entity.Address.ReverseMapAddress()
        };
    }
}