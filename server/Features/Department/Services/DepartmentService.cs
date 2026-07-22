using AutoMapper;
using DepartmentEntity = server.Entities.Department;
using server.Features.Department.DTOs;
using server.Features.Department.Interfaces;
using server.Repositories.Interfaces;

namespace server.Features.Department.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DepartmentService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DepartmentResponse>> GetAllAsync()
    {
        var departments = await _unitOfWork.Departments.GetAllWithOrganizationAsync();

        return _mapper.Map<IEnumerable<DepartmentResponse>>(departments);
    }

    public async Task<DepartmentResponse?> GetByIdAsync(int id)
    {
        var department = await _unitOfWork.Departments.GetByIdWithOrganizationAsync(id);

        if (department == null)
            return null;

        return _mapper.Map<DepartmentResponse>(department);
    }

    public async Task<DepartmentResponse> CreateAsync(CreateDepartmentRequest request)
    {
        var department = _mapper.Map<DepartmentEntity>(request);

        department.CreatedAt = DateTime.UtcNow;
        department.IsActive = true;

        await _unitOfWork.Departments.AddAsync(department);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<DepartmentResponse>(department);
    }

    public async Task<bool> UpdateAsync(int id, UpdateDepartmentRequest request)
    {
        var department = await _unitOfWork.Departments.GetByIdAsync(id);

        if (department == null)
            return false;

        department.DepartmentName = request.DepartmentName;
        department.Description = request.Description;
        department.OrganizationId = request.OrganizationId;
        department.IsActive = request.IsActive;
        department.UpdatedAt = DateTime.UtcNow;

        _unitOfWork.Departments.Update(department);

        await _unitOfWork.CommitAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var department = await _unitOfWork.Departments.GetByIdAsync(id);

        if (department == null)
            return false;

        department.IsActive = false;
        department.UpdatedAt = DateTime.UtcNow;

        _unitOfWork.Departments.Update(department);

        await _unitOfWork.CommitAsync();

        return true;
    }
}