using Entities.Models;

namespace Repository.Extensions;

public static class RepositoryJobExtensions
{
    public static IQueryable<Job>
        Filter(this IQueryable<Job> jobs, string? type, bool? hasMultipleSpots, bool? isTakingApplications)
    {
        if (!string.IsNullOrWhiteSpace(type))
        {
            jobs = jobs.Where(j => j.Type.ToLower() == type.ToLower());
        }

        if (hasMultipleSpots != null)
        {
            jobs = jobs.Where(j => j.HasMultipleSpots == hasMultipleSpots);
        }

        if (isTakingApplications != null)
        {
            jobs = jobs.Where(j => j.IsTakingApplications == isTakingApplications);
        }

        return jobs;
  
        
    }

    public static IQueryable<Job> Search(this IQueryable<Job> jobs, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm)) return jobs;
        return jobs.Where(j =>
            j.Employer != null && (j.Title.ToLower().Contains(searchTerm.ToLower()) ||
                                   j.Employer.Name.ToLower().Contains(searchTerm.ToLower()))
        );
    }
}