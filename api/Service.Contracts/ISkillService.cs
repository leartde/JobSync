using Shared.DataTransferObjects.SkillDtos;

namespace Service.Contracts;

public interface ISkillService
{
    Task<IEnumerable<ViewSkillDto>> GetSkillsForJobAsync(Guid employerId, Guid jobId);
    Task<IEnumerable<ViewSkillDto>> GetSkillsForJobSeekerAsync(Guid jobSeekerId);
    Task<IEnumerable<ViewSkillDto>> AddSkillsForJobAsync(Guid employerId, Guid jobId,
        List<string> skills);
    Task<IEnumerable<ViewSkillDto>> AddSkillsForJobSeekerAsync(Guid jobSeekerId,
        List<string> skills);

    Task DeleteSkillForJobAsync(Guid employerId, Guid jobId, Guid skillId);
    Task DeleteSkillForJobSeekerAsync(Guid jobSeekerId, Guid skillId);
    Task DeleteSkillsForJobAsync(Guid employerId, Guid jobId, List<Guid> skillIds);
    Task DeleteSkillsForJobSeekerAsync(Guid jobSeekerId,List<Guid> skillIds);

}