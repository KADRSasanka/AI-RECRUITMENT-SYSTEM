using server.DTOs.Resume;

namespace server.Interfaces;

public interface IResumeService
{
    Task<ResumeResponseDto> UploadAsync(
        UploadResumeDto dto);


    Task<IEnumerable<ResumeResponseDto>> 
        GetByCandidateIdAsync(int candidateId);


    Task<bool> DeleteAsync(int id);
}