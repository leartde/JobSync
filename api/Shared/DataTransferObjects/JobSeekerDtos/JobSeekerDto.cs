
namespace Shared.DataTransferObjects.JobSeekerDtos;

public abstract class JobSeekerDto
{
    public Guid? UserId { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public DateOnly? Birthday { get; set; }
    public string? Gender { get; set; }
    public string? Phone { get; set; }
    public string? SecondaryPhone { get; set; }
    
}