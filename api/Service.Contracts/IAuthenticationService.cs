using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects.UserDtos;

namespace Service.Contracts;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(RegisterUserDto userDto);
    Task<bool> ValidateUser(LoginUserDto userDto);
    Task<string> CreateToken();
}