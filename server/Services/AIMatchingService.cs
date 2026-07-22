using server.DTOs.AI;
using server.Interfaces;

namespace server.Services;

public class AIMatchingService : IAIMatchingService
{
    public async Task<AIMatchingResponseDto> AnalyzeCandidateAsync(
        string resumeText,
        string jobDescription)
    {

        // Temporary AI logic
        // Later this will connect with OpenAI / ML model

        int score = 0;


        var resumeWords =
            resumeText
            .ToLower()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);


        var jobWords =
            jobDescription
            .ToLower()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);



        var matchedSkills =
            resumeWords
            .Intersect(jobWords)
            .Count();



        if(jobWords.Length > 0)
        {
            score =
                (matchedSkills * 100) / jobWords.Length;
        }



        return new AIMatchingResponseDto
        {
            MatchScore = score,

            Recommendation =
                score >= 70
                ? "Strong Candidate"
                : score >= 40
                ? "Moderate Candidate"
                : "Low Match",

            MatchedKeywords =
                resumeWords
                .Intersect(jobWords)
                .ToList()
        };

    }

    public Task<CandidateMatchResponseDto> AnalyzeCandidateAsync(int candidateId, int jobId)
    {
        throw new NotImplementedException();
    }

}