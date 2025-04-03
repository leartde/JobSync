using Shared.DataTransferObjects.AddressDtos;
using Shared.DataTransferObjects.SkillDtos;

namespace Shared.DataTransferObjects.JobDtos;

public abstract class JobDto
{
    
    public string? Title { get; set; }
    public string? Description { get; set; }
    public double? HourlyPay { get; set; } 
    public string? Type { get; set; }
    public bool? IsTakingApplications { get; set; }
    public bool? HasMultipleSpots { get; set; }
    public DateOnly? CreatedAt { get; set; }
    public IEnumerable<string>? Benefits { get; set; }
}