using Entities.Enums;
using Entities.Models;
using Shared.DataTransferObjects.JobBenefitDtos;

namespace Shared.Mapping;

public static class JobBenefitMapping
{
    public static JobBenefitDto ToDto(this JobBenefit entity)
    {
        return new JobBenefitDto
        {
            JobId = entity.JobId,
            Benefit = entity.Benefit.ToString()
        };
    }

    public static void ToEntity(this JobBenefitDto dto, JobBenefit entity)
    {
        entity.JobId = dto.JobId;
        entity.Benefit = (Benefit)Enum.Parse(typeof(Benefit), dto.Benefit);
    }
}