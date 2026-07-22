namespace server.DTOs.AI;


public interface IAIAnalyzerService
{

    Task<AIAnalysisResult>
        AnalyzeAsync(
            string resumeText,
            string jobDescription);

}