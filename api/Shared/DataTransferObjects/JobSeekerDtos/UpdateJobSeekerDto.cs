using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObjects.JobSeekerDtos;

public class UpdateJobSeekerDto : JobSeekerDto
{
    public IFormFile? Resume { get; init; } 
}