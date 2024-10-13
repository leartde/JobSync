namespace Entities.Models;

public class JobSeekersSkills
{
    public JobSeeker? JobSeeker { get; set; }
    public Guid JobSeekerId { get; set; }
    public Skill? Skill { get; set; }
    public Guid SkillId { get; set; }
    
}