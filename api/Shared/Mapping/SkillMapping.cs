using Entities.Models;
using Shared.DataTransferObjects.SkillDtos;

namespace Shared.Mapping;

public static class SkillMapping
{
    public static ViewSkillDto ToDto(this Skill entity)
    {
        return new ViewSkillDto
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }

    public static void ToEntity(this SkillDto dto,Skill entity )
    {
        entity.Name = dto.Name;
    }
}