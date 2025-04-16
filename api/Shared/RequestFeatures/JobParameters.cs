namespace Shared.RequestFeatures;

public class JobParameters : RequestParameters
{
    public string JobType { get; set; } = string.Empty;
    public double? MinimumPay { get; set; }
    public bool? HasMultipleSpots { get; set; } 
    public bool? IsTakingApplications { get; set; }
    public bool? IsRemote { get; set; }
}