namespace server.DTOs.AI;


public class AIMatchingResponseDto
{

    public int MatchScore { get; set; }


    public string Recommendation { get; set; }
        = string.Empty;


    public List<string> MatchedKeywords { get; set; }
        = new();

}