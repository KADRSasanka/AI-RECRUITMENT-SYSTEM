namespace server.DTOs.Interview;


public class InterviewResponseDto
{

    public int InterviewId { get; set; }


    public int ApplicationId { get; set; }


    public string CandidateName { get; set; } = string.Empty;


    public string JobTitle { get; set; } = string.Empty;


    public DateTime InterviewDate { get; set; }


    public string InterviewType { get; set; } = string.Empty;


    public string Status { get; set; } = string.Empty;


    public string? MeetingLink { get; set; }


    public string? Feedback { get; set; }


    public decimal? Rating { get; set; }


}