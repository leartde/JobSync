using Entities.Models;
using Shared.DataTransferObjects.JobDtos;

namespace Shared.Mapping;

public static class JobMapping
{
    public static ViewJobDto MapJobDto(this Job entity)
    {
        return new ViewJobDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Location = entity.Location.MapAddressDto(),
            Pay = entity.Pay,
            Description = entity.Description,
            Type = entity.Type,
            IsTakingApplications = entity.IsTakingApplications,
            HasMultipleSpots = entity.HasMultipleSpots,
            CreatedAt = entity.CreatedAt,
            Employer = entity.Employer?.Name ?? string.Empty,
            Skills = entity.Skills?.Select(s => s.Skill?.Name ?? string.Empty)
        };
    }

    public static Job ReverseMapJob(this JobDto entity)
    {
        return new Job
        {
            Title = entity.Title,
            Pay = entity.Pay,
            Description = entity.Description,
            Type = entity.Type,
            IsTakingApplications = entity.IsTakingApplications,
            HasMultipleSpots = entity.HasMultipleSpots,
            CreatedAt = entity.CreatedAt,
            EmployerId = entity.EmployerId
        };
    }
}