using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class EmployerRepository : RepositoryBase<Employer>, IEmployerRepository
{
    public EmployerRepository(RepositoryContext context) : base(context){}
    public async Task<IEnumerable<Employer>> GetAllEmployersAsync()
    {
        return await FindAll().OrderBy(e => e.Industry)
            .Include(e => e.Address)
            .ToListAsync();
    }

    public async Task<Employer> GetEmployerAsync()
    {
        throw new NotImplementedException();
    }

    public void AddEmployer(Employer employer)
    {
        Create(employer);
    }

    public void DeleteEmployer(Employer employer)
    {
        throw new NotImplementedException();
    }

    public void UpdateEmployer(Employer employer)
    {
        throw new NotImplementedException();
    }
}