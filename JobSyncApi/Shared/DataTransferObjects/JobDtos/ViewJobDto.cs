using Shared.DataTransferObjects.AddressDtos;

namespace Shared.DataTransferObjects.JobDtos;

public class ViewJobDto : JobDto
{
    public Guid Id { get; set; }
    public string Employer { get; set; } = string.Empty;
    public ViewAddressDto? Location { get; set; }
    public IEnumerable<string>? Skills { get; set; }
}