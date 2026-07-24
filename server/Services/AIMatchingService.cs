using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.AI;
using server.Interfaces;

namespace server.Services;


public class AIMatchingService : IAIMatchingService
{

    private readonly ApplicationDbContext _context;


    public AIMatchingService(
        ApplicationDbContext context)
    {
        _context = context;
    }




    public async Task<CandidateMatchResponseDto>
        AnalyzeCandidateAsync(
            int candidateId,
            int jobId)
    {


        var candidate =
            await _context.Candidates
            .Include(c => c.User)
            .FirstOrDefaultAsync(
                c => c.CandidateId == candidateId);



        var job =
            await _context.Jobs
            .FirstOrDefaultAsync(
                j => j.JobId == jobId);



        if(candidate == null)
            throw new Exception(
                "Candidate not found");


        if(job == null)
            throw new Exception(
                "Job not found");



        /*
            Temporary Resume Text

            Later this connects
            Resume Parser
        */

        var resumeText =
            $"{candidate.User.FirstName} {candidate.User.LastName}";



        var jobText =
            job.JobDescription;



        var resumeWords =
            resumeText
            .ToLower()
            .Split(
                ' ',
                StringSplitOptions.RemoveEmptyEntries);



        var jobWords =
            jobText
            .ToLower()
            .Split(
                ' ',
                StringSplitOptions.RemoveEmptyEntries);



        var matched =
            resumeWords
            .Intersect(jobWords)
            .ToList();



        decimal score = 0;


        if(jobWords.Length > 0)
        {
            score =
            (decimal)matched.Count /
            jobWords.Length *
            100;
        }




        return new CandidateMatchResponseDto
        {

            CandidateId =
                candidateId,


            JobId =
                jobId,


            CandidateName =
                $"{candidate.User.FirstName}{ candidate.User.LastName }",


            JobTitle =
                job.JobTitle,


            MatchScore =
                Math.Round(score,2),



            Recommendation =
                score >= 70
                ?
                "Strong Candidate"
                :
                score >= 40
                ?
                "Moderate Candidate"
                :
                "Low Match",



            MatchedKeywords =
                matched,


            Strengths =
                string.Join(
                    ", ",
                    matched),



            MissingSkills =
                "Advanced AI extraction pending"

        };

    }

    public Task<AIMatchingResponseDto> AnalyzeCandidateAsync(string resumeText, string jobDescription)
    {
        throw new NotImplementedException();
    }
}