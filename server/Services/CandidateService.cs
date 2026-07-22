using server.DTOs.Candidate;
using server.Entities;
using server.Repositories.Interfaces;
using server.Services.Interfaces;

namespace server.Services;


public class CandidateService : ICandidateService
{

    private readonly ICandidateRepository _repository;


    public CandidateService(
        ICandidateRepository repository)
    {
        _repository = repository;
    }



    public async Task<IEnumerable<CandidateResponseDto>> GetAllAsync()
    {

        var candidates =
            await _repository.GetAllAsync();


        return candidates.Select(c =>
            new CandidateResponseDto
            {
                CandidateId = c.CandidateId,

                UserId = c.UserId,

                CurrentPosition = c.CurrentPosition,

                CurrentCompany = c.CurrentCompany,

                YearsOfExperience = c.YearsOfExperience,

                ProfileSummary = c.ProfileSummary,

                CreatedAt = c.CreatedAt
            });

    }



    public async Task<CandidateResponseDto?> GetByIdAsync(
        int id)
    {

        var candidate =
            await _repository.GetByIdAsync(id);


        if(candidate == null)
            return null;



        return new CandidateResponseDto
        {
            CandidateId = candidate.CandidateId,

            UserId = candidate.UserId,

            CurrentPosition = candidate.CurrentPosition,

            CurrentCompany = candidate.CurrentCompany,

            YearsOfExperience = candidate.YearsOfExperience,

            ProfileSummary = candidate.ProfileSummary,

            CreatedAt = candidate.CreatedAt
        };

    }



    public async Task<CandidateResponseDto> CreateAsync(
        CreateCandidateDto dto)
    {


        var candidate = new Candidate
        {

            UserId = dto.UserId,

            DateOfBirth = dto.DateOfBirth,

            Gender = dto.Gender,

            Nationality = dto.Nationality,

            CurrentPosition = dto.CurrentPosition,

            CurrentCompany = dto.CurrentCompany,

            YearsOfExperience = dto.YearsOfExperience,

            ExpectedSalary = dto.ExpectedSalary,

            Availability = dto.Availability,

            LinkedInUrl = dto.LinkedInUrl,

            GitHubUrl = dto.GitHubUrl,

            PortfolioUrl = dto.PortfolioUrl,

            ProfileSummary = dto.ProfileSummary

        };


        var result =
            await _repository.CreateAsync(candidate);



        return new CandidateResponseDto
        {
            CandidateId = result.CandidateId,

            UserId = result.UserId,

            CurrentPosition = result.CurrentPosition,

            CurrentCompany = result.CurrentCompany,

            YearsOfExperience = result.YearsOfExperience,

            ProfileSummary = result.ProfileSummary,

            CreatedAt = result.CreatedAt
        };

    }




    public async Task<bool> UpdateAsync(
        int id,
        UpdateCandidateDto dto)
    {

        var candidate =
            await _repository.GetByIdAsync(id);


        if(candidate == null)
            return false;



        candidate.DateOfBirth = dto.DateOfBirth;

        candidate.Gender = dto.Gender;

        candidate.Nationality = dto.Nationality;

        candidate.CurrentPosition = dto.CurrentPosition;

        candidate.CurrentCompany = dto.CurrentCompany;

        candidate.YearsOfExperience =
            dto.YearsOfExperience;

        candidate.ExpectedSalary =
            dto.ExpectedSalary;

        candidate.Availability =
            dto.Availability;

        candidate.LinkedInUrl =
            dto.LinkedInUrl;

        candidate.GitHubUrl =
            dto.GitHubUrl;

        candidate.PortfolioUrl =
            dto.PortfolioUrl;

        candidate.ProfileSummary =
            dto.ProfileSummary;


        candidate.UpdatedAt =
            DateTime.UtcNow;


        await _repository.UpdateAsync(candidate);


        return true;

    }




    public async Task<bool> DeleteAsync(int id)
    {

        var candidate =
            await _repository.GetByIdAsync(id);


        if(candidate == null)
            return false;



        await _repository.DeleteAsync(candidate);


        return true;

    }

}