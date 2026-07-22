using server.DTOs.ResumeProfile;

namespace server.Interfaces;


public interface IResumeParserService
{

    Task<ResumeProfileResponseDto>
        ParseResumeAsync(int resumeId);

}