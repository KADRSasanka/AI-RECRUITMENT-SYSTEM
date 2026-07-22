using AutoMapper;
using OrganizationEntity = server.Entities.Organization;
using server.Features.Organization.DTOs;
using server.Features.Organization.Interfaces;
using server.Repositories.Interfaces;

namespace server.Features.Organization.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrganizationService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrganizationResponse>> GetAllAsync()
    {
        var organizations = await _unitOfWork.Organizations.GetAllAsync();

        return _mapper.Map<IEnumerable<OrganizationResponse>>(organizations);
    }

    public async Task<OrganizationResponse?> GetByIdAsync(int id)
    {
        var organization = await _unitOfWork.Organizations.GetByIdAsync(id);

        if (organization == null)
            return null;

        return _mapper.Map<OrganizationResponse>(organization);
    }

    public async Task<OrganizationResponse> CreateAsync(CreateOrganizationRequest request)
    {
        var organization = _mapper.Map<OrganizationEntity>(request);

        organization.CreatedAt = DateTime.UtcNow;

        organization.IsActive = true;

        await _unitOfWork.Organizations.AddAsync(organization);

        await _unitOfWork.CommitAsync();

        return _mapper.Map<OrganizationResponse>(organization);
    }

    public async Task<bool> UpdateAsync(
        int id,
        UpdateOrganizationRequest request)
    {
        var organization = await _unitOfWork.Organizations.GetByIdAsync(id);

        if (organization == null)
            return false;

        organization.OrganizationName = request.OrganizationName;
        organization.Industry = request.Industry;
        organization.Website = request.Website;
        organization.Email = request.Email;
        organization.Phone = request.Phone;
        organization.Address = request.Address;
        organization.Description = request.Description;
        organization.IsActive = request.IsActive;
        organization.UpdatedAt = DateTime.UtcNow;

        _unitOfWork.Organizations.Update(organization);

        await _unitOfWork.CommitAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var organization = await _unitOfWork.Organizations.GetByIdAsync(id);

        if (organization == null)
            return false;

        organization.IsActive = false;

        organization.UpdatedAt = DateTime.UtcNow;

        _unitOfWork.Organizations.Update(organization);

        await _unitOfWork.CommitAsync();

        return true;
    }
}