namespace Entities.Models;

public class JobSkill
{
    public Job? Job { get; set; } 
    public Guid JobsId { get; set; }
    public Skill? Skill { get; set; }
    public Guid SkillsId { get; set; }
}