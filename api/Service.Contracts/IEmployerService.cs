using Entities.Models;
using Shared.DataTransferObjects.EmployerDtos;

namespace Service.Contracts;

public interface IEmployerService
{
    Task<IEnumerable<ViewEmployerDto>> GetAllEmployersAsync();
    Task<ViewEmployerDto?> GetEmployerAsync(Guid id);
    Task<ViewEmployerDto> AddEmployerAsync(AddEmployerDto employerDto);
    
    Task<ViewEmployerDto> UpdateEmployerAsync(Guid id, UpdateEmployerDto employerDto);
    Task DeleteEmployerAsync(Guid id);
}