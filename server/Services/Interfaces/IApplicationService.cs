using server.DTOs.Application;

namespace server.Interfaces;

public interface IApplicationService
{
    Task<IEnumerable<ApplicationResponseDto>> GetAllAsync();

    Task<ApplicationResponseDto?> GetByIdAsync(int id);

    Task<IEnumerable<ApplicationResponseDto>> GetByCandidateIdAsync(int candidateId);

    Task<IEnumerable<ApplicationResponseDto>> GetByJobIdAsync(int jobId);

    Task<ApplicationResponseDto> CreateAsync(CreateApplicationDto dto);

    Task<bool> UpdateAsync(int id, UpdateApplicationDto dto);
}