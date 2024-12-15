using Shared.DataTransferObjects.AddressDtos;

namespace Shared.DataTransferObjects.JobSeekerDtos;

public class ViewJobSeekerDto : JobSeekerDto
{
    public Guid Id { get; set; }
    public new ViewAddressDto? Address { get; set; }
    public string? ResumeLink { get; set; }
    public new IEnumerable<string>? Skills { get; set; }
}