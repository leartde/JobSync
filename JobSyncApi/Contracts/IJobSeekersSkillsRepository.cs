using Entities.Models;

namespace Contracts;

public interface IJobSeekersSkillsRepository
{
    Task<IEnumerable<JobSeekersSkills>> GetAllJobSeekersSkills();
    Task<JobSeekersSkills> GetJobsSeekersSkills(Guid jobSeekerId, Guid skillId);
    void AddJobsSeekersSkills(JobSeekersSkills jobSeekersSkills);
    void DeleteJobsSeekrsSkills(JobSeekersSkills jobSeekersSkills);
}