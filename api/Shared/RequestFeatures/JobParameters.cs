namespace Shared.RequestFeatures;

public class JobParameters : RequestParameters
{
    public JobParameters() => OrderBy = "createdAt";
    public string JobType { get; set; } = string.Empty;
    public string SearchTerm { get; set; } = string.Empty;
    public bool? HasMultipleSpots { get; set; } 
    public bool? IsTakingApplications { get; set; }
}