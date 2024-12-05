using Entities.Enums;

namespace Entities.Models;

public class JobBenefit
{
    public Job? Job { get; set; }
    public Guid JobId { get; set; }
    public Benefit Benefit { get; set; }
}