using Entities.Models;
using Shared.DataTransferObjects.JobDtos;

namespace Shared.Mapping;

public static class JobMapping
{
    public static ViewJobDto ToDto(this Job entity)
    {
        return new ViewJobDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Address = $"{entity.Address?.Street} {entity.Address?.Region ?? entity.Address?.State}"
                + $"{entity.Address?.Country} {entity.Address?.ZipCode}",
            Pay = entity.Pay,
            Description = entity.Description,
            Type = entity.Type,
            ImageUrl = entity.ImageUrl,
            IsTakingApplications = entity.IsTakingApplications,
            HasMultipleSpots = entity.HasMultipleSpots,
            CreatedAt = entity.CreatedAt,
            Employer = entity.Employer?.Name ?? string.Empty,
            Skills = entity.Skills.Select(s => s.Name),
            Benefits = entity.Benefits.Select(b => b.Benefit.ToString())
            
        };
        
    }

    public static void ToEntity(this JobDto dto, Job entity)
    {
        entity.Title = dto.Title ?? entity.Title;
        entity.Pay = dto.Pay ?? entity.Pay;
        entity.Description = dto.Description ?? entity.Description;
        entity.Type = dto.Type ?? entity.Type;
        entity.IsTakingApplications = dto.IsTakingApplications ?? entity.IsTakingApplications;
        entity.HasMultipleSpots = dto.HasMultipleSpots ?? entity.HasMultipleSpots;
        entity.CreatedAt = dto.CreatedAt ?? entity.CreatedAt;
            
    if (dto is AddJobDto addJobDto)
        {
            addJobDto.Skills?.ToList().ForEach(skillDto => 
                entity.Skills.ToList().ForEach(skill => 
                    skillDto.ToEntity(skill)));
        }
    }
}