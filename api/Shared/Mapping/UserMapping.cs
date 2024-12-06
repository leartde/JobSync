using Entities.Models;
using Shared.DataTransferObjects.UserDtos;

namespace Shared.Mapping;

public static class UserMapping
{
     public static ViewUserDto MapUserDto(this AppUser entity)
     {
         return new ViewUserDto
         {
             Id = entity.Id,
             Email = entity.Email ?? string.Empty
         };
     }

     public static void ReverseMapUser(this UserDto dto, AppUser entity)
     {
         entity.Email = dto.Email;
         entity.UserName = dto.Email;
     }
}