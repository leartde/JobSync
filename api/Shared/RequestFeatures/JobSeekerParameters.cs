namespace Shared.RequestFeatures;

public class JobSeekerParameters : RequestParameters
{
    public JobSeekerParameters() => OrderBy = "lastName";
    public IEnumerable<string>? Skills { get; set; }
    public string? SearchTerm { get; set; }
}