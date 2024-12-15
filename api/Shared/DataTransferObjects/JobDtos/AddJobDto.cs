using Microsoft.AspNetCore.Http;
using Shared.DataTransferObjects.AddressDtos;
using Shared.DataTransferObjects.SkillDtos;

namespace Shared.DataTransferObjects.JobDtos;

public class AddJobDto : JobDto
{
    public IFormFile? Image { get; set; }
    public AddressDto? Address { get; set; }
    public List<AddSkillDto>? Skills { get; set; }
}