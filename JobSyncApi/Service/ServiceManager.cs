using Contracts;
using Service.Contracts;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAddressService> _addressService;
    private readonly Lazy<IJobService> _jobService;
    private readonly Lazy<IEmployerService> _employerService;

    public ServiceManager(IRepositoryManager repository, ILoggerManager logger)
    {
        _addressService = new Lazy<IAddressService>(() => new
            AddressService(repository, logger));
        _jobService = new Lazy<IJobService>(() => new
            JobService(repository, logger)
        );
        _employerService = new Lazy<IEmployerService>(() => new
            EmployerService(repository, logger)
        );
    }

    public IAddressService AddressService => _addressService.Value;
    public IJobService JobService => _jobService.Value;
    public IEmployerService EmployerService => _employerService.Value;
}