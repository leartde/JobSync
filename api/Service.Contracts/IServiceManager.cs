namespace Service.Contracts;

public interface IServiceManager
{
    IAddressService AddressService { get; }
    IJobService JobService { get; }
    IEmployerService EmployerService { get;  }
    IJobSeekerService JobSeekerService { get; }
    IAuthenticationService AuthenticationService { get; }
    
}