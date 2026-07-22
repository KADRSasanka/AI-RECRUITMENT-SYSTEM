using server.DTOs.Interview;

namespace server.Services
{
    public interface IInterviewService
    {
        Task<IEnumerable<InterviewResponseDto>> GetAllAsync();

        Task<InterviewResponseDto?> GetByIdAsync(int id);

        Task<InterviewResponseDto> CreateAsync(CreateInterviewDto dto);

        Task<bool> UpdateAsync(int id, UpdateInterviewDto dto);

        Task<bool> DeleteAsync(int id);
    }
}