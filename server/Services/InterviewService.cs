using server.DTOs.Interview;
using server.Entities;
using server.Interfaces;

namespace server.Services
{
    public class InterviewService : IInterviewService
    {
        private readonly IInterviewRepository _repository;

        public InterviewService(IInterviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<InterviewResponseDto>> GetAllAsync()
        {
            var interviews = await _repository.GetAllAsync();

            return interviews.Select(i => new InterviewResponseDto
            {
                InterviewId = i.InterviewId,
                ApplicationId = i.ApplicationId,
                InterviewDate = i.InterviewDate,
                InterviewType = i.InterviewType,
                Status = i.Status,
                MeetingLink = i.MeetingLink,
                Feedback = i.Feedback,
                Rating = i.Rating
            });
        }

        public async Task<InterviewResponseDto?> GetByIdAsync(int id)
        {
            var interview = await _repository.GetByIdAsync(id);
            if (interview == null) return null;

            return new InterviewResponseDto
            {
                InterviewId = interview.InterviewId,
                ApplicationId = interview.ApplicationId,
                InterviewDate = interview.InterviewDate,
                InterviewType = interview.InterviewType,
                Status = interview.Status,
                MeetingLink = interview.MeetingLink,
                Feedback = interview.Feedback,
                Rating = interview.Rating
            };
        }

        public async Task<InterviewResponseDto> CreateAsync(CreateInterviewDto dto)
        {
            var interview = new Interview
            {
                ApplicationId = dto.ApplicationId,
                InterviewerId = dto.InterviewerId,
                InterviewDate = dto.InterviewDate,
                InterviewType = dto.InterviewType,
                MeetingLink = dto.MeetingLink,
                Status = "Scheduled",
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(interview);

            return new InterviewResponseDto
            {
                InterviewId = interview.InterviewId,
                ApplicationId = interview.ApplicationId,
                InterviewDate = interview.InterviewDate,
                InterviewType = interview.InterviewType,
                Status = interview.Status,
                MeetingLink = interview.MeetingLink,
                Feedback = interview.Feedback,
                Rating = interview.Rating
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateInterviewDto dto)
        {
            var interview = await _repository.GetByIdAsync(id);
            if (interview == null) return false;

            interview.Status = dto.Status;
            interview.Feedback = dto.Feedback;
            interview.Rating = dto.Rating;
            interview.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(interview);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var interview = await _repository.GetByIdAsync(id);
            if (interview == null) return false;

            await _repository.DeleteAsync(interview);
            return true;
        }

        public async Task<IEnumerable<InterviewResponseDto>> GetByApplicationIdAsync(int applicationId)
        {
            var interviews = await _repository.GetByApplicationIdAsync(applicationId);

            return interviews.Select(i => new InterviewResponseDto
            {
                InterviewId = i.InterviewId,
                ApplicationId = i.ApplicationId,
                InterviewDate = i.InterviewDate,
                InterviewType = i.InterviewType,
                Status = i.Status,
                MeetingLink = i.MeetingLink,
                Feedback = i.Feedback,
                Rating = i.Rating
            });
        }
    }
}