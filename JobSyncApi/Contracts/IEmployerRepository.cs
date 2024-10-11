using Entities.Models;

namespace Contracts;

public interface IEmployerRepository
{
    Task<IEnumerable<Employer>> GetAllEmployersAsync();
    Task<Employer> GetEmployerAsync();
    void AddEmployer(Employer employer);
    void DeleteEmployer(Employer employer);
    void UpdateEmployer(Employer employer);

}
    