using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Entities;
using server.Repositories.Interfaces;

namespace server.Repositories;


public class CandidateRepository : ICandidateRepository
{

    private readonly ApplicationDbContext _context;


    public CandidateRepository(
        ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task<IEnumerable<Candidate>> GetAllAsync()
    {
        return await _context.Candidates
            .ToListAsync();
    }



    public async Task<Candidate?> GetByIdAsync(int id)
    {
        return await _context.Candidates
            .FirstOrDefaultAsync(x =>
            x.CandidateId == id);
    }



    public async Task<Candidate> CreateAsync(
        Candidate candidate)
    {

        await _context.Candidates.AddAsync(candidate);

        await _context.SaveChangesAsync();

        return candidate;
    }



    public async Task UpdateAsync(
        Candidate candidate)
    {
        _context.Candidates.Update(candidate);

        await _context.SaveChangesAsync();
    }



    public async Task DeleteAsync(
        Candidate candidate)
    {

        _context.Candidates.Remove(candidate);

        await _context.SaveChangesAsync();

    }

}