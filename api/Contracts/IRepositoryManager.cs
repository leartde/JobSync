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
    IApplicationRepository Application { get; }
    Task SaveAsync();
}