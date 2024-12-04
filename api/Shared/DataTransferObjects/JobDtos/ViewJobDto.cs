using Shared.DataTransferObjects.AddressDtos;
using Shared.DataTransferObjects.EmployerDtos;

namespace Shared.DataTransferObjects.JobDtos;

public class ViewJobDto : JobDto
{
    public Guid Id { get; set; }
    public ViewEmployerDto? Employer { get; set; }
    public IEnumerable<string>? Skills { get; set; }

    
}