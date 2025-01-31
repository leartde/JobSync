using Entities.Models;
using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Moq;
using Service.Contracts;
using Shared.DataTransferObjects.JobSeekerDtos;
using Shared.Mapping;
using Shared.RequestFeatures;
using Tests.Data;
using Validation.Validators;
using Validation.Validators.JobSeeker;

namespace Tests.Services;

public class JobSeekerServiceTests
{
    private readonly Mock<IJobSeekerService> _mockService;
    private List<JobSeeker> _jobSeekers;
    private readonly AddJobSeekerValidator _validator;

    public JobSeekerServiceTests()
    {
        _mockService = new Mock<IJobSeekerService>();
        _jobSeekers = FakeJobSeekers.JobSeekers;
        _validator = new AddJobSeekerValidator();
    }

    [Fact]
    public async Task GetAllJobSeekers_ShouldReturnListOfAllJobSeekers_WhenNullParametersAreGiven()
    {
        //Arrange
        JobSeekerParameters jobSeekerParams = new();

        _mockService.Setup(service => service.GetAllJobSeekersAsync(jobSeekerParams))
            .ReturnsAsync(new PagedList<ViewJobSeekerDto>(
                _jobSeekers.Select(js => js.ToDto()).ToList(),
                2,
                1,
                2
            ));
        
        //Act
        var result = await _mockService.Object.GetAllJobSeekersAsync(jobSeekerParams);
        
        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<PagedList<ViewJobSeekerDto>>();
        result.Should().HaveCount(2);

    }

    [Fact]
    public async Task GetAllJobSeekers_ShouldReturnLimitedJobSeekers_WhenPaginationParametersAreGiven()
    {
        //Arrange
        JobSeekerParameters jobSeekerParameters = new()
        {
            PageNumber = 2,
            PageSize = 1,
        };

        _mockService.Setup(service => service.GetAllJobSeekersAsync(jobSeekerParameters))
            .ReturnsAsync(new PagedList<ViewJobSeekerDto>(
                    _jobSeekers.Select(js => js.ToDto())
                        .Skip((jobSeekerParameters.PageNumber - 1) * jobSeekerParameters.PageSize)
                        .Take(jobSeekerParameters.PageSize)
                        .ToList()
                    ,
                    _jobSeekers.Count,
                    jobSeekerParameters.PageNumber,
                    jobSeekerParameters.PageSize
                )
            );
        
        //Act
        var result = await _mockService.Object.GetAllJobSeekersAsync(jobSeekerParameters);
        
        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<PagedList<ViewJobSeekerDto>>();
        result.Should().HaveCount(jobSeekerParameters.PageSize);
        result.Should().NotContainEquivalentOf(_jobSeekers.First().ToDto());
        result.Should().ContainEquivalentOf(_jobSeekers[1].ToDto());
    }

    [Fact]
    public async Task GetJobSeekerAsync_ShouldReturnJobSeekerDto_IfExists()
    {
        //Arrange
        Guid id = new Guid("0d7aab1c-36a0-494e-ace0-6477a2b1203e");
        _mockService.Setup(service => service.GetJobSeekerAsync(id))
            .ReturnsAsync(_jobSeekers.Single(js => js.Id.Equals(id)).ToDto);
        
        //Act
        var result = await _mockService.Object.GetJobSeekerAsync(id);
        
        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ViewJobSeekerDto>();
        result.Should().BeEquivalentTo(_jobSeekers.First().ToDto());
    }

    [Fact]
    public async Task ValidateJobSeeker_ShouldReturnTrue_WhenItPasses()
    {
        //Arrange
        AddJobSeekerDto jobSeekerDto = new()
        {
            FirstName = "John",
            LastName = "Doe",
            Gender = "Male"
        };
        
        //Act
        var result = await _validator.ValidateAsync(jobSeekerDto);
        
        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ValidationResult>();
        result.IsValid.Should().BeTrue();

    }

    [Fact]
    public async Task ValidateJobSeeker_ShouldReturnValidationError_WhenNoNameIsGiven()
    {
        //Arrange
        AddJobSeekerDto jobSeekerDto = new()
        {
            Gender = "Male"
        };
        
        //Act
        var result = await _validator.ValidateAsync(jobSeekerDto);
        
        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ValidationResult>();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(AddJobSeekerDto.FirstName));
        result.Errors.Should().Contain(e => e.PropertyName == nameof(AddJobSeekerDto.LastName));
    }
    
    [Fact]
    public async Task ValidateJobSeeker_ShouldReturnValidationError_WhenInvalidResumeFileTypeIsGiven()
    {
        //Arrange
        string fileName = "wrongformat.jpg";
        MemoryStream stream = new ();
        AddJobSeekerDto jobSeekerDto = new()
        {
            FirstName = "John",
            LastName = "Smith",
            Gender = "Male",
            Resume = new FormFile(stream, 0, stream.Length, "resume", fileName)
        };
        //Act
        var result = await _validator.ValidateAsync(jobSeekerDto);
        
        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ValidationResult>();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(AddJobSeekerDto.Resume));
    }

    [Fact]
    public async Task AddJobSeekerAsync_ShouldAddItToTheList_AndReturnJobSeekerDto()
    {
        //Arrange
        AddJobSeekerDto jobSeekerDto = new()
        {
            FirstName = "Danny",
            LastName = "Daniels",
            Gender = "Male",
            Phone = "+100 144 999"
        };
        JobSeeker jobSeeker = new()
        {
            Id = Guid.NewGuid()
        };
        _mockService.Setup(service => service.AddJobSeekerAsync(jobSeekerDto))
            .Callback<AddJobSeekerDto>((dto) =>
            {
                dto.ToEntity(jobSeeker);
                _jobSeekers.Add(jobSeeker);
            })
            .ReturnsAsync(jobSeeker.ToDto);
        
        //Act
        var result = await _mockService.Object.AddJobSeekerAsync(jobSeekerDto);
        
        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ViewJobSeekerDto>();
        _jobSeekers.Should().ContainEquivalentOf(jobSeeker);
    }

    [Fact]
    public async Task UpdateJobSeeker_ShouldUpdateGivenJobSeeker_AndReturnIt()
    {
        //Arrange
        UpdateJobSeekerDto jobSeekerDto = new()
        {
            FirstName = "UpdatedName"
        };
        Guid id = new Guid("0d7aab1c-36a0-494e-ace0-6477a2b1203e");
        JobSeeker jobSeeker = _jobSeekers.First();
        _mockService.Setup(service => service.UpdateJobSeekerAsync(id, jobSeekerDto))
            .Callback<Guid, UpdateJobSeekerDto>((jsId, dto) =>
            {
                dto.ToEntity(jobSeeker);
            })
            .ReturnsAsync(jobSeeker.ToDto);
        
        //Act
        var result = await _mockService.Object.UpdateJobSeekerAsync(id, jobSeekerDto);
        
        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ViewJobSeekerDto>();
        result.Should().BeEquivalentTo(jobSeeker.ToDto());
        _jobSeekers.First(js => js.Id.Equals(id))
            .Should().BeEquivalentTo(jobSeeker);
    }

    [Fact]
    public async Task DeleteJobSeekerAsync_ShouldRemoveItFromListOfJobSeekers()
    {
        //Arrange
        Guid id = new Guid("0d7aab1c-36a0-494e-ace0-6477a2b1203e");
        _mockService.Setup(service => service.DeleteJobSeekerAsync(id))
            .Callback<Guid>(jsId =>
            {
                JobSeeker jobSeeker = _jobSeekers.Single(js => js.Id.Equals(jsId));
                _jobSeekers.Remove(jobSeeker);
            });
        
        //Act
        await _mockService.Object.DeleteJobSeekerAsync(id);
        
        //Assert
        _jobSeekers.SingleOrDefault(js => js.Id.Equals(id)).Should().BeNull();
    }
}