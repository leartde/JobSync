using Entities.Models;
using Shared.DataTransferObjects.EmployerDtos;

namespace Service.Contracts;

public interface IEmployerService
{
    Task<IEnumerable<ViewEmployerDto>> GetAllEmployersAsync();
    Task<ViewEmployerDto?> GetEmployerAsync(Guid id);
    Task<Employer> AddEmployerAsync(AddEmployerDto employerDto);
    
    Task<Employer> UpdateEmployerAsync(Guid id, UpdateEmployerDto employerDto);
    Task DeleteEmployerAsync(Guid id);
}