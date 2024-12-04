namespace Entities.Models;

public class Skill
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Industry { get; set; }
    public List<Job>? Jobs { get; set; }
    public List<JobSeeker>? JobSeekers { get; set; }
}