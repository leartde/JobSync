using Shared.DataTransferObjects.AddressDtos;

namespace Shared.DataTransferObjects.JobSeekerDtos;

public class ViewJobSeekerDto : JobSeekerDto
{
    public Guid Id { get; set; }
    public string? Address { get; set; }
    public string? ResumeLink { get; set; }
    public IEnumerable<string>? Skills { get; set; }
}