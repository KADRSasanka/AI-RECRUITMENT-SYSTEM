namespace server.DTOs.Interview;


public class UpdateInterviewDto
{

    public string Status { get; set; } = string.Empty;


    public string? Feedback { get; set; }


    public decimal? Rating { get; set; }


}