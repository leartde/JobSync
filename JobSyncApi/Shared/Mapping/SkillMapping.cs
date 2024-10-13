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

    public static Skill ReverseMapSkill(this SkillDto entity)
    {
        return new Skill
        {
            Name = entity.Name,
            Industry = entity.Industry
        };
    }
}