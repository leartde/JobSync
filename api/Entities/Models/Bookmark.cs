namespace Entities.Models;

public class Bookmark
{
    public Job? Job { get; set; }
    public Guid JobId { get; set; }
    public JobSeeker? JobSeeker { get; set; }
    public Guid JobSeekerId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}