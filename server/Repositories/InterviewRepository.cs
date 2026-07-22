using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Interfaces;
using server.Entities;


namespace server.Repositories;


public class InterviewRepository : IInterviewRepository
{

    private readonly ApplicationDbContext _context;


    public InterviewRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Interview>> GetAllAsync()
    {
        return await _context.Interviews
            .Include(x=>x.Application)
            .ThenInclude(x=>x!.Candidate)
            .Include(x=>x.Application!.Job)
            .ToListAsync();
    }



    public async Task<Interview?> GetByIdAsync(int id)
    {
        return await _context.Interviews
            .Include(x=>x.Application)
            .ThenInclude(x=>x!.Candidate)
            .Include(x=>x.Application!.Job)
            .FirstOrDefaultAsync(x=>x.InterviewId==id);
    }



    public async Task<IEnumerable<Interview>> GetByApplicationIdAsync(
        int applicationId)
    {

        return await _context.Interviews
            .Where(x=>x.ApplicationId==applicationId)
            .ToListAsync();

    }



    public async Task<Interview> AddAsync(
        Interview interview)
    {

        _context.Interviews.Add(interview);

        await _context.SaveChangesAsync();

        return interview;

    }



    public async Task UpdateAsync(
        Interview interview)
    {

        _context.Interviews.Update(interview);

        await _context.SaveChangesAsync();

    }

    public Task DeleteAsync(Interview interview)
    {
        throw new NotImplementedException();
    }
}