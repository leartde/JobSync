using Entities.Models;
using Shared.DataTransferObjects.JobSeekerDtos;
using Shared.DataTransferObjects.SkillDtos;

namespace Shared.Mapping;

public static class JobSeekerMapping
{
    public static ViewJobSeekerDto ToDto(this JobSeeker entity)
    {
        return new ViewJobSeekerDto
        {
            Id = entity.Id,
            UserId = entity.UserId,
            FirstName = entity.FirstName,
            MiddleName = entity.MiddleName,
            LastName = entity.LastName,
            Phone = entity.Phone,
            Gender = entity.Gender,
            SecondaryPhone = entity.SecondaryPhone,
            Birthday = entity.Birthday,
            ResumeLink = entity.ResumeLink,
            Skills = entity.Skills.Select(s => s.Name),
            Address = entity.Address != null
                ? $"{entity.Address.Street}, {entity.Address.City}, {entity.Address.Region ?? entity.Address.State}"
                  + $", {entity.Address.Country}, {entity.Address.ZipCode}"
                : ""
        };
    }

    public static void ToEntity(this JobSeekerDto dto,JobSeeker entity)
    {
        entity.UserId = dto.UserId ?? entity.UserId;
        entity.FirstName = dto.FirstName??entity.FirstName;
        entity.MiddleName = dto.MiddleName??entity.MiddleName;
        entity.LastName = dto.LastName??entity.LastName;
        entity.Phone = dto.Phone??entity.Phone;
        entity.SecondaryPhone = dto.SecondaryPhone??entity.SecondaryPhone;
        entity.Birthday = dto.Birthday??entity.Birthday;
        entity.Gender = dto.Gender??entity.Gender;
        if (dto is AddJobSeekerDto addJobSeekerDto)
        {
            if (addJobSeekerDto.Address != null)
            {
                Address address = new Address();
                addJobSeekerDto.Address.ToEntity(address);
                entity.Address = address;
            }
        }
    }
}