using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared.DataTransferObjects.JobDtos;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAddressService> _addressService;
    private readonly Lazy<IJobService> _jobService;
    private readonly Lazy<IEmployerService> _employerService;
    private readonly Lazy<IJobSeekerService> _jobSeekerService;
    private readonly Lazy<IAuthenticationService> _authenticationService;
    private readonly Lazy<IJobApplicationService> _applicationService;

    public ServiceManager(IRepositoryManager repository, ILoggerManager logger, UserManager<AppUser>
        userManager, IConfiguration configuration,IDataShaper<ViewJobDto>dataShaper, 
        ICloudinaryManager _cloudinaryManager
        )
    {
        _addressService = new Lazy<IAddressService>(() => new
            AddressService(repository, logger));
        _jobService = new Lazy<IJobService>(() => new
            JobService(repository, logger, dataShaper, _cloudinaryManager));
        _employerService = new Lazy<IEmployerService>(() => new
            EmployerService(repository, logger)
        );
        _jobSeekerService = new Lazy<IJobSeekerService>(() => new 
            JobSeekerService(repository, logger, _cloudinaryManager)
            );
        _authenticationService = new Lazy<IAuthenticationService>(() => new
            AuthenticationService(userManager,configuration)
        );
        _applicationService = new Lazy<IJobApplicationService>(() => new
            JobApplicationService(repository));
    }

    public IAddressService AddressService => _addressService.Value;
    public IJobService JobService => _jobService.Value;
    public IEmployerService EmployerService => _employerService.Value;
    public IJobSeekerService JobSeekerService => _jobSeekerService.Value;
    public IAuthenticationService AuthenticationService => _authenticationService.Value;
    public IJobApplicationService JobApplicationService => _applicationService.Value;
}