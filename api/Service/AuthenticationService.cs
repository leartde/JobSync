using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.DataTransferObjects.UserDtos;
using Shared.Mapping;

namespace Service;

internal sealed class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;
    private AppUser? _user;

    public AuthenticationService(UserManager<AppUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }
    public async Task<IdentityResult> RegisterUser(RegisterUserDto userDto)
    {
        AppUser user = new AppUser();
        userDto.ToEntity(user);
        IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);
        if (result.Succeeded) await _userManager.AddToRoleAsync(user, userDto.Role);
        return result;
    }

    public async Task<bool> ValidateUser(LoginUserDto userDto)
    {
        _user = await _userManager.FindByEmailAsync(userDto.Email);
        bool result = (_user != null && await _userManager.CheckPasswordAsync(_user, userDto.Password));
        return result;
    }

    public async Task<string> CreateToken()
    {
        SigningCredentials signingCredentials = GetSigningCredentials();
        List<Claim> claims = await GetClaims();
        JwtSecurityToken tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private SigningCredentials GetSigningCredentials()
    {
        byte[] key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET") ?? string.Empty);
        SymmetricSecurityKey secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaims()
    {
        List<Claim> claims = [new Claim("email", _user?.Email ?? string.Empty)];
        if (_user == null) return claims;
        IList<string> roles = await _userManager.GetRolesAsync(_user);
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        IConfigurationSection jwtSettings = _configuration.GetSection("JwtSettings");
        JwtSecurityToken tokenOptions = new JwtSecurityToken(issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"], claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials);
        return tokenOptions;
    }
}