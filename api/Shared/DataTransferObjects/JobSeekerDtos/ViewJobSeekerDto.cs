using Shared.DataTransferObjects.AddressDtos;

namespace Shared.DataTransferObjects.JobSeekerDtos;

public class ViewJobSeekerDto : JobSeekerDto
{
    public Guid Id { get; set; }
    public ViewAddressDto? Address { get; set; }
    public IEnumerable<string>? Skills { get; set; }
}