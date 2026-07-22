using server.DTOs.AI;


namespace server.Interfaces;


public interface IAIMatchingService
{

    Task<CandidateMatchResponseDto>
        AnalyzeCandidateAsync(
            int candidateId,
            int jobId);

    Task<AIMatchingResponseDto> AnalyzeCandidateAsync(
        string resumeText,
        string jobDescription
    );

}