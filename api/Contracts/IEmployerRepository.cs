using Entities.Models;

namespace Contracts;

public interface IEmployerRepository
{
    Task<IEnumerable<Employer>> GetAllEmployersAsync();
    Task<Employer> GetEmployerAsync(Guid id);
    Task AddEmployerAsync(Employer employer);
    void DeleteEmployer(Employer employer);
    void UpdateEmployer(Employer employer);

}
    