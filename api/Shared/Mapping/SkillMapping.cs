using Entities.Models;
using Shared.DataTransferObjects.SkillDtos;

namespace Shared.Mapping;

public static class SkillMapping
{
    public static ViewSkillDto MapSkillDto(this Skill entity)
    {
        return new ViewSkillDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Industry = entity.Industry
        };
    }

    public static void ReverseMapSkill(this SkillDto dto,Skill entity )
    {

        entity.Name = dto.Name;
        entity.Industry = dto.Industry;

    }
}