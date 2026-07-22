using server.Features.Department.DTOs;

namespace server.Features.Department.Interfaces;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentResponse>> GetAllAsync();

    Task<DepartmentResponse?> GetByIdAsync(int id);

    Task<DepartmentResponse> CreateAsync(CreateDepartmentRequest request);

    Task<bool> UpdateAsync(int id, UpdateDepartmentRequest request);

    Task<bool> DeleteAsync(int id);
}