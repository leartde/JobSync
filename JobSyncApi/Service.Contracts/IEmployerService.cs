using Entities.Models;
using Shared.DataTransferObjects.EmployerDtos;

namespace Service.Contracts;

public interface IEmployerService
{
    Task<IEnumerable<EmployerDto>> GetAllEmployersAsync();
    Task<EmployerDto> GetEmployerAsync(Guid id);
    Task CreateEmployerAsync(AddEmployerDto employerDto);
}