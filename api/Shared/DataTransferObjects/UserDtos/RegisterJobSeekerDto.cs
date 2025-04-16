using Shared.DataTransferObjects.JobSeekerDtos;

namespace Shared.DataTransferObjects.UserDtos;

public class RegisterJobSeekerDto : RegisterUserDto
{
    public AddJobSeekerDto AddJobSeekerDto { get; set; } = new();
}