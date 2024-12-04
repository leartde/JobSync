using Entities.Models;
using Shared.DataTransferObjects.JobDtos;
using Shared.DataTransferObjects.SkillDtos;

namespace Shared.Mapping;

public static class JobMapping
{
    public static ViewJobDto MapJobDto(this Job entity)
    {
        return new ViewJobDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Address = entity.Address.MapAddressDto(),
            Pay = entity.Pay,
            Description = entity.Description,
            Type = entity.Type,
            IsTakingApplications = entity.IsTakingApplications,
            HasMultipleSpots = entity.HasMultipleSpots,
            CreatedAt = entity.CreatedAt,
            Employer = entity.Employer?.MapEmployerDto(),
            Skills = entity.Skills.Select(s => s.Name),
            
        };
    }

    public static void ReverseMapJob(this JobDto dto,Job entity)
    {
        entity.Title = dto.Title??entity.Title;
        entity.Pay = dto.Pay??entity.Pay;
        entity.Description = dto.Description??entity.Description;
        entity.Type = dto.Type??entity.Type;
        entity.IsTakingApplications = dto.IsTakingApplications??entity.IsTakingApplications;
        entity.HasMultipleSpots = dto.HasMultipleSpots??entity.HasMultipleSpots;
        entity.CreatedAt = dto.CreatedAt??entity.CreatedAt;
        dto.Skills?.ToList().ForEach(skillDto => 
            entity.Skills.ToList().ForEach(skill => 
                skillDto.ReverseMapSkill(skill)));
    }
}