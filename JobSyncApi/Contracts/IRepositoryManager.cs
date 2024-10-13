namespace Contracts;

public interface IRepositoryManager
{
    IAddressRepository Address { get; }
    IEmployerRepository Employer { get; }
    IJobRepository Job { get; }
    ISkillRepository Skill { get; }
    IJobsSkillsRepository JobsSkills { get; }
    Task SaveAsync();
}