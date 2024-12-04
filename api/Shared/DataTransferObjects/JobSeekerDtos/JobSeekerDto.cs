using Shared.DataTransferObjects.AddressDtos;
using Shared.DataTransferObjects.SkillDtos;

namespace Shared.DataTransferObjects.JobSeekerDtos;

public class JobSeekerDto
{
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public DateOnly? Birthday { get; set; }
    public string? Gender { get; set; }
    // public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? SecondaryPhone { get; set; }
    public string? ResumeLink { get; set; }
    public AddressDto? Address { get; set; }
    public List<SkillDto>?Skills { get; set; }
}