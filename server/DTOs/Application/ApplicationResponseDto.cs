namespace server.DTOs.Application;


public class ApplicationResponseDto
{

    public int ApplicationId { get; set; }


    public int CandidateId { get; set; }


    public string CandidateName { get; set; } = string.Empty;



    public int JobId { get; set; }


    public string JobTitle { get; set; } = string.Empty;



    public DateTime AppliedDate { get; set; }



    public string Status { get; set; } = string.Empty;



    public decimal? Score { get; set; }



    public string? RecruiterRemarks { get; set; }



    public string? AIRecommendation { get; set; }



    public DateTime CreatedAt { get; set; }

}