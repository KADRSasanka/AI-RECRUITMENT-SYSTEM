using DepartmentEntity = server.Entities.Department;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Features.Department.Interfaces;
using server.Repositories;

namespace server.Features.Department.Repositories;

public class DepartmentRepository
    : BaseRepository<DepartmentEntity>, IDepartmentRepository
{
    public DepartmentRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<DepartmentEntity>> GetAllWithOrganizationAsync()
    {
        return await Context.Departments
            .Include(d => d.Organization)
            .OrderBy(d => d.DepartmentName)
            .ToListAsync();
    }

    public async Task<DepartmentEntity?> GetByIdWithOrganizationAsync(int id)
    {
        return await Context.Departments
            .Include(d => d.Organization)
            .FirstOrDefaultAsync(d => d.DepartmentId == id);
    }
}