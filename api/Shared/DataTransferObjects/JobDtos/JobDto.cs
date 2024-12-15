using Shared.DataTransferObjects.AddressDtos;
using Shared.DataTransferObjects.SkillDtos;

namespace Shared.DataTransferObjects.JobDtos;

public  class JobDto
{
    
    public string? Title { get; set; }
    public string? Pay { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
    public bool? IsTakingApplications { get; set; }
    public bool? HasMultipleSpots { get; set; }
    public DateOnly? CreatedAt { get; set; }
    
    
}