namespace server.DTOs.AI;


public class AIAnalysisResult
{

    public decimal Score { get; set; }


    public string Strengths { get; set; }
        = "";


    public string MissingSkills { get; set; }
        = "";


    public string Recommendation { get; set; }
        = "";

}