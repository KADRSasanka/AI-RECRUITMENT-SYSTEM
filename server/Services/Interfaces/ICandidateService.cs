using server.DTOs.Candidate;

namespace server.Services.Interfaces;

public interface ICandidateService
{
    Task<IEnumerable<CandidateResponseDto>> GetAllAsync();

    Task<CandidateResponseDto?> GetByIdAsync(int id);

    Task<CandidateResponseDto> CreateAsync(
        CreateCandidateDto dto);

    Task<bool> UpdateAsync(
        int id,
        UpdateCandidateDto dto);

    Task<bool> DeleteAsync(int id);
}