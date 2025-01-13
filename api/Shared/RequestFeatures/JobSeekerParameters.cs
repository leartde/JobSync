namespace Shared.RequestFeatures;

public class JobSeekerParameters : RequestParameters
{
    public IEnumerable<string>? Skills { get; set; }
    public string? SearchTerm { get; set; }
}