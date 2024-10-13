using Entities.Models;

namespace Shared.DataTransferObjects.SkillDtos;

public class ViewSkillDto : SkillDto
{
    public Guid Id { get; set; }
}