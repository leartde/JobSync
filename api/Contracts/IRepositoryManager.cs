namespace Contracts;

public interface IRepositoryManager
{
    IAddressRepository Address { get; }
    IEmployerRepository Employer { get; }
    IJobRepository Job { get; }
    ISkillRepository Skill { get; }
    IJobSkillRepository JobSkill { get; }
    IJobSeekerRepository JobSeeker { get; }
    IJobSeekerSkillRepository JobSeekerSkill { get; }
    IJobApplicationRepository JobApplication { get; }
    IJobBenefitRepository JobBenefit { get; }
    IBookmarkRepository Bookmark { get; }
    Task SaveAsync();
}