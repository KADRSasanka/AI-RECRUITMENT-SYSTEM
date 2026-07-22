using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Entities;

namespace server.Repositories.Interfaces;

public class JobRepository : IJobRepository
{
    private readonly ApplicationDbContext _context;

    public JobRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Job>> GetAllAsync()
    {
        return await _context.Jobs
            .Include(j => j.Organization)
            .Include(j => j.Department)
            .Include(j => j.Recruiter)
            .ToListAsync();
    }

    public async Task<Job?> GetByIdAsync(int id)
    {
        return await _context.Jobs
            .Include(j => j.Organization)
            .Include(j => j.Department)
            .Include(j => j.Recruiter)
            .FirstOrDefaultAsync(j => j.JobId == id);
    }

    public async Task<IEnumerable<Job>> GetByOrganizationAsync(int organizationId)
    {
        return await _context.Jobs
            .Where(j => j.OrganizationId == organizationId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Job>> GetByDepartmentAsync(int departmentId)
    {
        return await _context.Jobs
            .Where(j => j.DepartmentId == departmentId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Job>> SearchAsync(string keyword)
    {
        return await _context.Jobs
            .Where(j =>
                j.JobTitle.Contains(keyword) ||
                j.JobDescription.Contains(keyword))
            .ToListAsync();
    }

    public async Task AddAsync(Job job)
    {
        await _context.Jobs.AddAsync(job);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Job job)
    {
        _context.Jobs.Update(job);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Job job)
    {
        _context.Jobs.Remove(job);
        await _context.SaveChangesAsync();
    }
}