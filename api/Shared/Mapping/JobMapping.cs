using Entities.Enums;
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
            Address = entity.Address != null?$"{entity.Address.Street}, {entity.Address.City}, {entity.Address.Region ?? entity.Address.State}"
                + $"{entity.Address.Country}, {entity.Address.ZipCode}":"Remote",
            Pay = $"${entity.HourlyPay}/hour",
            Description = entity.Description,
            Type = entity.Type,
            ImageUrl = entity.ImageUrl,
            IsTakingApplications = entity.IsTakingApplications,
            HasMultipleSpots = entity.HasMultipleSpots,
            CreatedAt = entity.CreatedAt,
            Employer = entity.Employer?.Name ?? string.Empty,
            EmployerId = entity.EmployerId,
            Skills = entity.Skills.Select(s => s.Name),
            Benefits = entity.Benefits.Select(b => b.Benefit.ToString()),
            City = entity.Address?.City
            
        };
        
    }

    public static void ToEntity(this JobDto dto, Job entity)
    {
        entity.Title = dto.Title;
        entity.HourlyPay = dto.HourlyPay;
        entity.Description = dto.Description;
        entity.Type = dto.Type;
        entity.IsTakingApplications = dto.IsTakingApplications;
        entity.HasMultipleSpots = dto.HasMultipleSpots;
        entity.CreatedAt = dto.CreatedAt;
            
    if (dto is AddJobDto addJobDto)
        {
            if (addJobDto.Address != null)
            {
                Address address = new Address();
                addJobDto.Address.ToEntity(address);
                entity.Address = address;
            }

            if (addJobDto.Benefits.Any())
            {
                List<JobBenefit> jobBenefits = [];
                jobBenefits.AddRange(addJobDto.Benefits
                    .Select(benefit => new JobBenefit
                    {
                        JobId = entity.Id,
                        Benefit = (Benefit)Enum.Parse(typeof(Benefit), benefit)
                    }));
                entity.Benefits = jobBenefits;
            }
            
        }
    }
}