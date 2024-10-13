namespace Entities.Models;

public class Skill
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Industry { get; set; }
    public List<JobsSkills>? Jobs { get; set; }
    public List<JobSeekersSkills>? JobSeekers { get; set; }
}