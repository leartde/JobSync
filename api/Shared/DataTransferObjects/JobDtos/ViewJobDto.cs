using Shared.DataTransferObjects.AddressDtos;
using Shared.DataTransferObjects.EmployerDtos;

namespace Shared.DataTransferObjects.JobDtos;

public class ViewJobDto : JobDto
{
    public Guid Id { get; set; }
    public string Employer { get; set; } = string.Empty;
    public new IEnumerable<string>? Skills { get; set; } 


}