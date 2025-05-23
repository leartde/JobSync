﻿using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.EmployerDtos;
using Shared.Mapping;
using Shared.RequestFeatures;

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

    public async Task<PagedList<ViewEmployerDto>> GetAllEmployersAsync(EmployerParameters employerParameters)
    {
        PagedList<Employer> employers = await _repository.Employer.GetAllEmployersAsync(employerParameters);
        List<ViewEmployerDto> employerDtos = employers.Select(e => e.ToDto()).ToList();
        return new PagedList<ViewEmployerDto>(employerDtos, employers.MetaData.TotalCount, employerParameters.PageNumber,employerParameters.PageSize);
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
        await _repository.Employer.AddEmployerAsync(employer);
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
        Employer employer = await _repository.Employer.GetEmployerAsync(id);
        if (employer is null) throw new NotFoundException("employer", id);
        return employer;
    }
}