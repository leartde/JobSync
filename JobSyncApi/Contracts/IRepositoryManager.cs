namespace Contracts;

public interface IRepositoryManager
{
    IAddressRepository Address { get; }
    IEmployerRepository Employer { get; }
    IJobRepository Job { get; }
    Task SaveAsync();
}