using server.DTOs.Job;

namespace server.Services.Interfaces;

public interface IJobService
{
    Task<IEnumerable<JobResponseDto>> GetAllAsync();

    Task<JobResponseDto?> GetByIdAsync(int id);

    Task<JobResponseDto> CreateAsync(CreateJobDto dto);

    Task<bool> UpdateAsync(int id, UpdateJobDto dto);

    Task<bool> DeleteAsync(int id);
}