namespace Shared.DataTransferObjects.UserDtos;

public class AddUserDto : UserDto
{
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}