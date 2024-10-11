using Entities.Models;
using Shared.DataTransferObjects.EmployerDtos;

namespace Shared.Mapping;

public static class EmployerMapping
{
    public static EmployerDto MapEmployerDto(this Employer entity)
    {
        return new EmployerDto
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

    public static Employer ReverseMapEmployer(this AddEmployerDto entity)
    {
        return new Employer
        {
            Name = entity.Name,
            Industry = entity.Industry,
            Founded = entity.Founded,
            Phone = entity.Phone,
            SecondaryPhone = entity.Phone,
            Address = entity.Address?.ReverseMapAddress()
        };
    }
}