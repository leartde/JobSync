namespace Entities.Models;

public class JobSeekerSkill
{
    public JobSeeker? JobSeeker { get; set; }
    public Guid JobSeekersId { get; set; }
    public Skill? Skill { get; set; }
    public Guid SkillsId { get; set; }
    
}