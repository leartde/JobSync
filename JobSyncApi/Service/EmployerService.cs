using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.EmployerDtos;
using Shared.Mapping;

namespace Service;

internal sealed class EmployerService : IEmployerService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public EmployerService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<EmployerDto>> GetAllEmployersAsync()
    {
        IEnumerable<Employer> employers = await _repository.Employer.GetAllEmployersAsync();
        IEnumerable<EmployerDto> employerDtos = employers.Select(e => e.MapEmployerDto());
        return employerDtos;
    }

    public async Task<EmployerDto> GetEmployerAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task CreateEmployerAsync(AddEmployerDto employerDto)
    {
        Address address = employerDto.Address.ReverseMapAddress();
        _repository.Address.AddAddress(address);
        Employer employer = employerDto.ReverseMapEmployer();
        _repository.Employer.AddEmployer(employer);
        await _repository.SaveAsync();

    }
}