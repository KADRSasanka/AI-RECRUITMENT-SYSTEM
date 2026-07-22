namespace server.DTOs.Interview;


public class CreateInterviewDto
{

    public int ApplicationId { get; set; }


    public int InterviewerId { get; set; }


    public DateTime InterviewDate { get; set; }


    public string InterviewType { get; set; } = string.Empty;


    public string? MeetingLink { get; set; }

}