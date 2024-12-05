using Entities.Enums;

namespace Entities.Models;

public class Application
{
    public Guid Id { get; set; }
    public Job? Job { get; set; } 
    public Guid JobId { get; set; }
    public JobSeeker? JobSeeker { get; set; }
    public Guid JobSeekerId { get; set; }
    public ApplicationStatus Status { get; set; } = 0;

}