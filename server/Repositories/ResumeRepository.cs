using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Entities;
using server.Interfaces;

namespace server.Repositories;

public class ResumeRepository : IResumeRepository
{
    private readonly ApplicationDbContext _context;


    public ResumeRepository(ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task<Resume?> GetByIdAsync(int id)
    {
        return await _context.Resumes
            .Include(r => r.Candidate)
            .FirstOrDefaultAsync(r => r.ResumeId == id);
    }



    public async Task<IEnumerable<Resume>> GetByCandidateIdAsync(int candidateId)
    {
        return await _context.Resumes
            .Where(r => r.CandidateId == candidateId)
            .ToListAsync();
    }



    public async Task<Resume> AddAsync(Resume resume)
    {
        _context.Resumes.Add(resume);

        await _context.SaveChangesAsync();

        return resume;
    }



    public async Task DeleteAsync(Resume resume)
    {
        _context.Resumes.Remove(resume);

        await _context.SaveChangesAsync();
    }
}