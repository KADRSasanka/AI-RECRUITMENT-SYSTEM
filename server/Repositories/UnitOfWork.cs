using server.Data;
using server.Features.Department.Interfaces;
using server.Features.Organization.Interfaces;
using server.Repositories.Interfaces;

namespace server.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IOrganizationRepository Organizations { get; }

    public IDepartmentRepository Departments { get; }

    public UnitOfWork(
        ApplicationDbContext context,
        IOrganizationRepository organizations,
        IDepartmentRepository departments)
    {
        _context = context;

        Organizations = organizations;

        Departments = departments;
    }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }
}