using server.DTOs.Job;
using server.Services.Interfaces;
using server.Entities;
using server.Repositories;


namespace server.Services;


public class JobService : IJobService
{

    private readonly IJobRepository _repository;


    public JobService(IJobRepository repository)
    {
        _repository = repository;
    }



    public async Task<IEnumerable<JobResponseDto>> GetAllAsync()
    {
        var jobs = await _repository.GetAllAsync();


        return jobs.Select(job => new JobResponseDto
        {
            JobId = job.JobId,

            JobTitle = job.JobTitle,

            JobDescription = job.JobDescription,

            EmploymentType = job.EmploymentType,

            WorkMode = job.WorkMode,

            Location = job.Location,

            ExperienceLevel = job.ExperienceLevel,

            SalaryMin = job.SalaryMin,

            SalaryMax = job.SalaryMax,

            Currency = job.Currency,

            NumberOfVacancies = job.NumberOfVacancies,

            ClosingDate = job.ClosingDate,

            IsActive = job.IsActive,

            CreatedAt = job.CreatedAt,

            OrganizationName = job.Organization?.OrganizationName ?? "",

            DepartmentName = job.Department?.DepartmentName ?? ""
        });
    }



    public async Task<JobResponseDto?> GetByIdAsync(int id)
    {
        var job = await _repository.GetByIdAsync(id);


        if(job == null)
            return null;


        return new JobResponseDto
        {
            JobId = job.JobId,

            JobTitle = job.JobTitle,

            JobDescription = job.JobDescription,

            EmploymentType = job.EmploymentType,

            WorkMode = job.WorkMode,

            Location = job.Location,

            ExperienceLevel = job.ExperienceLevel,

            SalaryMin = job.SalaryMin,

            SalaryMax = job.SalaryMax,

            Currency = job.Currency,

            NumberOfVacancies = job.NumberOfVacancies,

            ClosingDate = job.ClosingDate,

            IsActive = job.IsActive,

            CreatedAt = job.CreatedAt
        };
    }





    public async Task<JobResponseDto> CreateAsync(CreateJobDto dto)
    {

        var job = new Job
        {

            OrganizationId = dto.OrganizationId,

            DepartmentId = dto.DepartmentId,

            RecruiterId = dto.RecruiterId,


            JobTitle = dto.JobTitle,

            JobDescription = dto.JobDescription,


            EmploymentType = dto.EmploymentType,

            WorkMode = dto.WorkMode,


            Location = dto.Location,


            ExperienceLevel = dto.ExperienceLevel,


            SalaryMin = dto.SalaryMin,

            SalaryMax = dto.SalaryMax,


            Currency = dto.Currency,


            NumberOfVacancies = dto.NumberOfVacancies,


            ClosingDate = dto.ClosingDate,


            IsActive = true,


            CreatedAt = DateTime.UtcNow

        };


        await _repository.AddAsync(job);



        return await GetByIdAsync(job.JobId)
               ?? throw new Exception("Job creation failed");

    }






    public async Task<bool> UpdateAsync(int id, UpdateJobDto dto)
    {

        var job = await _repository.GetByIdAsync(id);


        if(job == null)
            return false;



        job.JobTitle = dto.JobTitle;

        job.JobDescription = dto.JobDescription;

        job.EmploymentType = dto.EmploymentType;

        job.WorkMode = dto.WorkMode;

        job.Location = dto.Location;

        job.ExperienceLevel = dto.ExperienceLevel;

        job.SalaryMin = dto.SalaryMin;

        job.SalaryMax = dto.SalaryMax;

        job.NumberOfVacancies = dto.NumberOfVacancies;

        job.ClosingDate = dto.ClosingDate;

        job.IsActive = dto.IsActive;


        job.UpdatedAt = DateTime.UtcNow;



        await _repository.UpdateAsync(job);


        return true;
    }






    public async Task<bool> DeleteAsync(int id)
    {

        var job = await _repository.GetByIdAsync(id);


        if(job == null)
            return false;



        await _repository.DeleteAsync(job);


        return true;
    }

}