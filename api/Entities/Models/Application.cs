namespace Entities.Models;

public class Application
{
    public Guid Id { get; set; }
    public Job Job { get; set; } = new();
    public Guid JobId { get; set; }
    public JobSeeker JobSeeker { get; set; } = new();
    public Guid JobSeekerId { get; set; }
    public string Status { get; set; } = "Applied";

}