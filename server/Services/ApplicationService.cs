using server.DTOs.Application;
using server.Interfaces;
using server.Entities;
using server.DTOs.Manager;


namespace server.Services;


public class ApplicationService : IApplicationService
{

    private readonly IApplicationRepository _repository;


    public ApplicationService(IApplicationRepository repository)
    {
        _repository = repository;
    }



    private ApplicationResponseDto MapToDto(Application application)
    {
        return new ApplicationResponseDto
        {

            ApplicationId = application.ApplicationId,


            CandidateId = application.CandidateId,


            CandidateName =
                application.Candidate?.User?.FullName ?? "",



            JobId = application.JobId,


            JobTitle =
                application.Job?.JobTitle ?? "",



            AppliedDate = application.AppliedDate,


            Status = application.Status,


            Score = application.Score,


            RecruiterRemarks =
                application.RecruiterRemarks,



            AIRecommendation =
                application.AIRecommendation,



            CreatedAt = application.CreatedAt

        };
    }




    public async Task<IEnumerable<ApplicationResponseDto>> GetAllAsync()
    {

        var applications = await _repository.GetAllAsync();


        return applications.Select(MapToDto);

    }




    public async Task<ApplicationResponseDto?> GetByIdAsync(int id)
    {

        var application =
            await _repository.GetByIdAsync(id);


        if(application == null)
            return null;


        return MapToDto(application);

    }




    public async Task<IEnumerable<ApplicationResponseDto>> GetByCandidateIdAsync(int candidateId)
    {

        var applications =
            await _repository.GetByCandidateIdAsync(candidateId);



        return applications.Select(MapToDto);

    }




    public async Task<IEnumerable<ApplicationResponseDto>> GetByJobIdAsync(int jobId)
    {

        var applications =
            await _repository.GetByJobIdAsync(jobId);



        return applications.Select(MapToDto);

    }





    public async Task<ApplicationResponseDto> CreateAsync(CreateApplicationDto dto)
    {

        var application = new Application
        {

            CandidateId = dto.CandidateId,


            JobId = dto.JobId,


            AppliedDate = DateTime.UtcNow,


            Status = "Applied",


            CreatedAt = DateTime.UtcNow

        };



        await _repository.AddAsync(application);



        var result =
            await _repository.GetByIdAsync(application.ApplicationId);



        return MapToDto(result!);

        

    }






    public async Task<bool> UpdateAsync(
        int id,
        UpdateApplicationDto dto)
    {

        var application =
            await _repository.GetByIdAsync(id);



        if(application == null)
            return false;




        application.Status = dto.Status;


        application.RecruiterRemarks =
            dto.RecruiterRemarks;



        application.Score =
            dto.Score;



        application.AIRecommendation =
            dto.AIRecommendation;



        application.UpdatedAt =
            DateTime.UtcNow;




        await _repository.UpdateAsync(application);



        return true;

    }

    public Task<bool> ManagerReviewAsync(int id, ManagerReviewDto dto)
    {
        throw new NotImplementedException();
    }
}