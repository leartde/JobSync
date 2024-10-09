namespace Entities.Models;

public class Job
{
    public Guid Id { get; set; }
    public Employer? Employer { get; set; }
    public Guid EmployerId { get; set; }
    public string Title { get; set; } = string.Empty;
    public Address? Location { get; set; }
    public Guid AddressId { get; set; }
    public string Pay { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public bool IsTakingApplications { get; set; }
    public bool HasMultipleSpots { get; set; }
    public DateOnly CreatedAt { get; set; }
    public List<Application>? Applications { get; set; }
    public List<Skill>? Skills { get; set; }


}