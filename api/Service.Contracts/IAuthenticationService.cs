using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects.UserDtos;

namespace Service.Contracts;

public interface IAuthenticationService
{
    Task<(IdentityResult Result, AppUser User)> RegisterUser(RegisterUserDto userDto);
    Task<bool> ValidateUser(LoginUserDto userDto);
    Task<string> CreateToken();
}