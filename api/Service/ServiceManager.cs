using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAddressService> _addressService;
    private readonly Lazy<IJobService> _jobService;
    private readonly Lazy<IEmployerService> _employerService;
    private readonly Lazy<IJobSeekerService> _jobSeekerService;
    private readonly Lazy<IAuthenticationService> _authenticationService;

    public ServiceManager(IRepositoryManager repository, ILoggerManager logger, UserManager<AppUser>
        userManager, IConfiguration configuration
        )
    {
        _addressService = new Lazy<IAddressService>(() => new
            AddressService(repository, logger));
        _jobService = new Lazy<IJobService>(() => new
            JobService(repository, logger)
        );
        _employerService = new Lazy<IEmployerService>(() => new
            EmployerService(repository, logger)
        );
        _jobSeekerService = new Lazy<IJobSeekerService>(() => new 
            JobSeekerService(repository, logger)
            );
        _authenticationService = new Lazy<IAuthenticationService>(() => new
            AuthenticationService(userManager,configuration)
        );
    }

    public IAddressService AddressService => _addressService.Value;
    public IJobService JobService => _jobService.Value;
    public IEmployerService EmployerService => _employerService.Value;
    public IJobSeekerService JobSeekerService => _jobSeekerService.Value;
    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}