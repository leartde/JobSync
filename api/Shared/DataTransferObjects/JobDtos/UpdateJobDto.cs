using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObjects.JobDtos;

public class UpdateJobDto : JobDto
{
    public IFormFile? Image { get; set; }
}