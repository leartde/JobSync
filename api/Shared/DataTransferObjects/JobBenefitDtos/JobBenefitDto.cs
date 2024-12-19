namespace Shared.DataTransferObjects.JobBenefitDtos;

public class JobBenefitDto
{
   public Guid JobId { get; set; }
   public string Benefit { get; set; } = string.Empty;
}