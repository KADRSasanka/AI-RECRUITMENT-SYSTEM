namespace server.Entities;


public class Interview
{

    public int InterviewId { get; set; }


    public int ApplicationId { get; set; }


    public Application? Application { get; set; }



    public int InterviewerId { get; set; }


    public User? Interviewer { get; set; }



    public DateTime InterviewDate { get; set; }


    public string InterviewType { get; set; } = string.Empty;


    public string Status { get; set; } = "Scheduled";


    public string? MeetingLink { get; set; }



    public string? Feedback { get; set; }



    public decimal? Rating { get; set; }



    public DateTime CreatedAt { get; set; }


    public DateTime? UpdatedAt { get; set; }

}