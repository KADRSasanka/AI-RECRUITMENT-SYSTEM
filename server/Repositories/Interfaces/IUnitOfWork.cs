using server.Features.Department.Interfaces;
using server.Features.Organization.Interfaces;

namespace server.Repositories.Interfaces;

public interface IUnitOfWork
{
    IOrganizationRepository Organizations { get; }

    IDepartmentRepository Departments { get; }

    Task<int> CommitAsync();
}