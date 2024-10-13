using Shared.DataTransferObjects.AddressDtos;
using Shared.DataTransferObjects.SkillDtos;

namespace Shared.DataTransferObjects.JobDtos;

public class AddJobDto : JobDto
{
    public AddAddressDto? Location { get; set; }
    public IEnumerable<AddSkillDto>? Skills { get; set; }
}