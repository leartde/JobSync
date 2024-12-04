using Entities.Models;
using Shared.DataTransferObjects.EmployerDtos;

namespace Service.Contracts;

public interface IEmployerService
{
    Task<IEnumerable<ViewEmployerDto>> GetAllEmployersAsync();
    Task<ViewEmployerDto?> GetEmployerAsync(Guid id);
    Task AddEmployerAsync(AddEmployerDto employerDto);
    Task DeleteEmployerAsync(Guid id);
    Task UpdateEmployerAsync(Guid id, UpdateEmployerDto employerDto);
}