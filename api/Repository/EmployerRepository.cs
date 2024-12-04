using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

internal sealed class EmployerRepository : RepositoryBase<Employer>, IEmployerRepository
{
    public EmployerRepository(RepositoryContext context) : base(context){}
    public async Task<IEnumerable<Employer>> GetAllEmployersAsync()
    {
        return await FindAll().OrderBy(e => e.Industry)
            .ToListAsync();
    }

    public async Task<Employer?> GetEmployerAsync(Guid id)
    {
        return await FindByCondition(e => e.Id.Equals(id))
           .SingleOrDefaultAsync();
    }

    public void AddEmployer(Employer employer)
    {
        Create(employer);
    }

    public void DeleteEmployer(Employer employer)
    {
        Delete(employer);
    }

    public void UpdateEmployer(Employer employer)
    {
        Update(employer);
    }
}