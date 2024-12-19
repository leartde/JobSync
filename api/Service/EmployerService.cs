﻿using Contracts;
using Entities.Exceptions;
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

    public async Task<IEnumerable<ViewEmployerDto>> GetAllEmployersAsync()
    {
        IEnumerable<Employer> employers = await _repository.Employer.GetAllEmployersAsync();
        IEnumerable<ViewEmployerDto> employerDtos = employers.Select(e => e.ToDto());
        return employerDtos;
    }

    public async Task<ViewEmployerDto?> GetEmployerAsync(Guid id)
    {
        Employer employer = await RetrieveEmployerAsync(id);
        return employer.ToDto();
    }

    public async Task<ViewEmployerDto> AddEmployerAsync(AddEmployerDto employerDto)
    {
        Employer employer = new Employer();
        employerDto.ToEntity(employer);
        _repository.Employer.AddEmployer(employer);
        await _repository.SaveAsync();
        return employer.ToDto();

    }

    public async Task DeleteEmployerAsync(Guid id)
    {
        Employer employer = await RetrieveEmployerAsync(id);
        _repository.Employer.DeleteEmployer(employer);
        await _repository.SaveAsync();
    }

    public async Task<ViewEmployerDto> UpdateEmployerAsync(Guid id,UpdateEmployerDto employerDto)
    {
        Employer employer = await RetrieveEmployerAsync(id);
            employerDto.ToEntity(employer);
        _repository.Employer.UpdateEmployer(employer);
        await _repository.SaveAsync();
        return employer.ToDto();
    }

    private async Task<Employer> RetrieveEmployerAsync(Guid id)
    {
        Employer? employer = await _repository.Employer.GetEmployerAsync(id);
        if (employer is null) throw new NotFoundException("employer", id);
        return employer;

    }
}