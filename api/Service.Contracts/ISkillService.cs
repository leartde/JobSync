using Shared.DataTransferObjects.SkillDtos;

namespace Service.Contracts;

public interface ISkillService
{
    Task<IEnumerable<ViewSkillDto>> AddSkillsForJobAsync(Guid employerId, Guid jobId,
        IEnumerable<AddSkillDto> skillDtos);
    Task<IEnumerable<ViewSkillDto>> AddSkillsForJobSeekerAsync(Guid jobSeekerId,
        IEnumerable<AddSkillDto> skillDtos);
    Task DeleteSkillsForJobAsync(Guid employerId, Guid jobId, List<Guid> skillIds);
    Task DeleteSkillsForJobSeekerAsync(Guid jobSeekerId,List<Guid> skillIds);

}