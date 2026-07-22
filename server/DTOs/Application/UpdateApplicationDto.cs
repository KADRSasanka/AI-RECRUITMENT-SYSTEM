namespace server.DTOs.Application;


public class UpdateApplicationDto
{

    public string Status { get; set; } = string.Empty;


    public string? RecruiterRemarks { get; set; }


    public decimal? Score { get; set; }


    public string? AIRecommendation { get; set; }

}