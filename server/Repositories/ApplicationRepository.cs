using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Entities;
using server.Interfaces;


namespace server.Repositories;


public class ApplicationRepository : IApplicationRepository
{

    private readonly ApplicationDbContext _context;


    public ApplicationRepository(ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task<IEnumerable<Application>> GetAllAsync()
    {
        return await _context.Applications
            .Include(x => x.Candidate)
                .ThenInclude(c => c.User)
            .Include(x => x.Job)
            .OrderByDescending(x => x.AppliedDate)
            .ToListAsync();
    }




    public async Task<Application?> GetByIdAsync(int id)
    {
        return await _context.Applications
            .Include(x => x.Candidate)
                .ThenInclude(c => c.User)
            .Include(x => x.Job)
            .FirstOrDefaultAsync(x => x.ApplicationId == id);
    }





    public async Task<IEnumerable<Application>> GetByCandidateIdAsync(int candidateId)
    {
        return await _context.Applications
            .Include(x=>x.Job)
            .Include(x => x.Candidate)
                .ThenInclude(c => c.User)
            .Where(x=>x.CandidateId == candidateId)
            .OrderByDescending(x => x.AppliedDate)
            .ToListAsync();
    }





    public async Task<IEnumerable<Application>> GetByJobIdAsync(int jobId)
    {
        return await _context.Applications
            .Include(x=>x.Candidate)
                .ThenInclude(c => c.User)
            .Include(x => x.Job)
            .Where(x=>x.JobId == jobId)
            .OrderByDescending(x => x.AppliedDate)
            .ToListAsync();
    }


    public async Task<bool> ExistsAsync(int candidateId, int jobId)
    {
        return await _context.Applications.AnyAsync(a =>
            a.CandidateId == candidateId &&
            a.JobId == jobId);
    }



    public async Task<Application> AddAsync(Application application)
    {

        _context.Applications.Add(application);

        await _context.SaveChangesAsync();

        return application;
        

    }





    public async Task UpdateAsync(Application application)
    {

        _context.Applications.Update(application);

        await _context.SaveChangesAsync();

    }


}