using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    private readonly Lazy<IAddressRepository> _addressRepository;
    private readonly Lazy<IEmployerRepository> _employerRepository;
    private readonly Lazy<IJobRepository> _jobRepository;
    private readonly Lazy<ISkillRepository> _skillRepository;
    private readonly Lazy<IJobsSkillsRepository> _jobsskillsRepository;

    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
        _addressRepository = new Lazy<IAddressRepository>(() => new
            AddressRepository(_context));
        _employerRepository = new Lazy<IEmployerRepository>(() => new
            EmployerRepository(_context));
        _jobRepository = new Lazy<IJobRepository>(() => new
            JobRepository(_context));
        _skillRepository = new Lazy<ISkillRepository>(() => new
            SkillRepository(_context));
        _jobsskillsRepository = new Lazy<IJobsSkillsRepository>(() => new
            JobsSkillsRepository(_context));
    }

    public IAddressRepository Address => _addressRepository.Value;
    public IEmployerRepository Employer => _employerRepository.Value;
    public IJobRepository Job => _jobRepository.Value;
    public ISkillRepository Skill => _skillRepository.Value;
    public IJobsSkillsRepository JobsSkills => _jobsskillsRepository.Value;
    public Task SaveAsync() => _context.SaveChangesAsync();
}