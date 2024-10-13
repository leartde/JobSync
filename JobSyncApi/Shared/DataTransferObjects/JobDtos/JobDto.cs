using Shared.DataTransferObjects.AddressDtos;

namespace Shared.DataTransferObjects.JobDtos;

public  class JobDto
{
    
    public string Title { get; set; } = string.Empty;
    public string Pay { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public bool IsTakingApplications { get; set; }
    public bool HasMultipleSpots { get; set; }
    public DateOnly CreatedAt { get; set; }
    public Guid EmployerId { get; set; }
    
}