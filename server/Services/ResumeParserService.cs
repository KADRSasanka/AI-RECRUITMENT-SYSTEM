using server.DTOs.ResumeProfile;
using server.Entities;
using server.Interfaces;

namespace server.Services;


public class ResumeParserService : IResumeParserService
{

    private readonly IResumeRepository _repository;


    public ResumeParserService(
        IResumeRepository repository)
    {
        _repository = repository;
    }



    public async Task<ResumeProfileResponseDto>
        ParseResumeAsync(int resumeId)
    {

        var resume =
            await _repository
            .GetByIdAsync(resumeId);



        if(resume == null)
            throw new Exception(
                "Resume not found");



        /*
          Temporary parser

          AI parser will replace this
        */


        var profile = new ResumeProfile
        {

            ResumeId = resumeId,


            FullName =
                resume.Candidate?
                .User?
                .FullName,


            Email =
                resume.Candidate?
                .User?
                .Email,


            Skills =
                "Pending AI Extraction",


            Education =
                "Pending AI Extraction",


            Experience =
                "Pending AI Extraction",


            Certifications =
                "Pending AI Extraction"

        };


        return new ResumeProfileResponseDto
        {
            ResumeId = profile.ResumeId,

            FullName = profile.FullName,

            Email = profile.Email,

            Skills = profile.Skills,

            Education = profile.Education,

            Experience = profile.Experience,

            Certifications =
                profile.Certifications
        };

    }

}