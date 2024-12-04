using Entities.Models;
using Shared.DataTransferObjects.JobSeekerDtos;

namespace Shared.Mapping;

public static class JobSeekerMapping
{
    public static ViewJobSeekerDto MapJobSeekerDto(this JobSeeker entity)
    {
        return new ViewJobSeekerDto
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            MiddleName = entity.MiddleName,
            LastName = entity.LastName,
            Phone = entity.Phone,
            Gender = entity.Gender,
            SecondaryPhone = entity.SecondaryPhone,
            Birthday = entity.Birthday,
            ResumeLink = entity.ResumeLink,
            Skills = entity.Skills.Select(s => s.Name),
            Address = entity.Address.MapAddressDto()
        };
    }

    public static void ReverseMapJobSeeker(this JobSeekerDto dto,JobSeeker entity)
    {
        
        entity.FirstName = dto.FirstName??entity.FirstName;
        entity.MiddleName = dto.MiddleName??entity.MiddleName;
        entity.LastName = dto.LastName??entity.LastName;
        entity.Phone = dto.Phone??entity.Phone;
        entity.SecondaryPhone = dto.SecondaryPhone??entity.SecondaryPhone;
        entity.Birthday = dto.Birthday??entity.Birthday;
        entity.Gender = dto.Gender??entity.Gender;
        entity.ResumeLink = dto.ResumeLink??entity.ResumeLink;
        dto.Skills?.ToList().ForEach(
            skillDto => entity.Skills.ToList().ForEach(
                skill => skillDto.ReverseMapSkill(skill)
                )
            );
    }
}