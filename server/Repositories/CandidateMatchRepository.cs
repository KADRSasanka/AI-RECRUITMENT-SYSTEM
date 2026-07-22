using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Entities;
using server.Interfaces;


namespace server.Repositories;


public class CandidateMatchRepository 
    : ICandidateMatchRepository
{

    private readonly ApplicationDbContext _context;


    public CandidateMatchRepository(
        ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task<CandidateMatch> AddAsync(
        CandidateMatch match)
    {

        _context.CandidateMatches.Add(match);

        await _context.SaveChangesAsync();

        return match;
    }




    public async Task<IEnumerable<CandidateMatch>>
        GetByJobIdAsync(int jobId)
    {

        return await _context.CandidateMatches
            .Where(x => x.JobId == jobId)
            .ToListAsync();

    }




    public async Task<IEnumerable<CandidateMatch>>
        GetByCandidateIdAsync(int candidateId)
    {

        return await _context.CandidateMatches
            .Where(x => x.CandidateId == candidateId)
            .ToListAsync();

    }

}