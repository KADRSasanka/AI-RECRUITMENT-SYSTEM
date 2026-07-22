using server.DTOs.AI;

namespace server.Services.AI;


public class AIAnalyzerService 
    : IAIAnalyzerService
{


    public Task<AIAnalysisResult>
        AnalyzeAsync(
            string resumeText,
            string jobDescription)
    {


        var skills = new[]
        {
            "C#",
            "ASP.NET",
            "SQL",
            "React",
            "JavaScript",
            "Docker"
        };


        var matchedSkills =
            skills
            .Where(skill =>
                resumeText
                .Contains(
                    skill,
                    StringComparison
                    .OrdinalIgnoreCase))
            .ToList();



        var score =
            (decimal)
            matchedSkills.Count /
            skills.Length * 100;



        var result =
            new AIAnalysisResult
            {

                Score = score,


                Strengths =
                    string.Join(
                        ", ",
                        matchedSkills),


                MissingSkills =
                    string.Join(
                        ", ",
                        skills.Except(
                            matchedSkills)),


                Recommendation =
                    score >= 60
                    ?
                    "Recommended"
                    :
                    "Needs Review"

            };



        return Task.FromResult(result);

    }

    Task<AIAnalysisResult> IAIAnalyzerService.AnalyzeAsync(string resumeText, string jobDescription)
    {
        throw new NotImplementedException();
    }
}