using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    private readonly Lazy<IAddressRepository> _addressRepository;
    private readonly Lazy<IEmployerRepository> _employerRepository;
    private readonly Lazy<IJobRepository> _jobRepository;
    private readonly Lazy<ISkillRepository> _skillRepository;
    private readonly Lazy<IJobSkillRepository> _jobSkillRepository;
    private readonly Lazy<IJobSeekerRepository> _jobSeekerRepository;
    private readonly Lazy<IJobSeekerSkillRepository> _jobSeekerSkillRepository;
    private readonly Lazy<IJobApplicationRepository> _applicationRepository;
    private readonly Lazy<IJobBenefitRepository> _jobBenefitRepository;

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
        _jobSkillRepository = new Lazy<IJobSkillRepository>(() => new
            JobSkillRepository(_context));
        _jobSeekerRepository = new Lazy<IJobSeekerRepository>(() => new
            JobSeekerRepository(_context));
        _jobSeekerSkillRepository = new Lazy<IJobSeekerSkillRepository>(() => new
            JobSeekerSkillRepository(_context)
        );
        _applicationRepository = new Lazy<IJobApplicationRepository>(() => new
            JobApplicationRepository(_context)
        );
        _jobBenefitRepository = new Lazy<IJobBenefitRepository>(() => new
            JobBenefitRepository(_context)
        );
    }

    public IAddressRepository Address => _addressRepository.Value;
    public IEmployerRepository Employer => _employerRepository.Value;
    public IJobRepository Job => _jobRepository.Value;
    public ISkillRepository Skill => _skillRepository.Value;
    public IJobSkillRepository JobSkill => _jobSkillRepository.Value;
    public IJobSeekerRepository JobSeeker => _jobSeekerRepository.Value;
    public IJobSeekerSkillRepository JobSeekerSkill => _jobSeekerSkillRepository.Value;
    public IJobApplicationRepository JobApplication => _applicationRepository.Value;
    public IJobBenefitRepository JobBenefit => _jobBenefitRepository.Value;
    public Task SaveAsync() => _context.SaveChangesAsync();
}