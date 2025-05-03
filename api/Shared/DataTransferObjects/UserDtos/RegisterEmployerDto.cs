using Shared.DataTransferObjects.EmployerDtos;

namespace Shared.DataTransferObjects.UserDtos;

public class RegisterEmployerDto : RegisterUserDto
{
    public AddEmployerDto Employer { get; set; } = new();

}