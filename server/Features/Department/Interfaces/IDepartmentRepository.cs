
using DepartmentEntity = server.Entities.Department;
using server.Repositories.Interfaces;

namespace server.Features.Department.Interfaces;

public interface IDepartmentRepository : IBaseRepository<DepartmentEntity>
{
    Task<IEnumerable<DepartmentEntity>> GetAllWithOrganizationAsync();

    Task<DepartmentEntity?> GetByIdWithOrganizationAsync(int id);
}