using Entities.Enums;
using Entities.Models;
using Shared.DataTransferObjects.JobBenefitDtos;

namespace Shared.Mapping;

public static class JobBenefitMapping
{
    public static ViewJobBenefitDto ToDto(this JobBenefit entity)
    {
        return new ViewJobBenefitDto
        {
            JobId = entity.JobId,
            Benefit = entity.Benefit.ToString()
        };
    }

    public static void ToEntity(this JobBenefitDto dto, JobBenefit entity)
    {
        entity.Benefit = (Benefit)Enum.Parse(typeof(Benefit), dto.Benefit);
    }
}