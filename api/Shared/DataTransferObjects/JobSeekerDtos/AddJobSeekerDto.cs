using Entities.Models;
using Microsoft.AspNetCore.Http;
using Shared.DataTransferObjects.AddressDtos;
using Shared.DataTransferObjects.SkillDtos;

namespace Shared.DataTransferObjects.JobSeekerDtos;

public class AddJobSeekerDto : JobSeekerDto
{
    public IFormFile? Resume { get; set; }
    
}