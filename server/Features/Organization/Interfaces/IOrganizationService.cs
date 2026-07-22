using server.Features.Organization.DTOs;

namespace server.Features.Organization.Interfaces;

public interface IOrganizationService
{
    Task<IEnumerable<OrganizationResponse>> GetAllAsync();

    Task<OrganizationResponse?> GetByIdAsync(int id);

    Task<OrganizationResponse> CreateAsync(CreateOrganizationRequest request);

    Task<bool> UpdateAsync(int id, UpdateOrganizationRequest request);

    Task<bool> DeleteAsync(int id);
}