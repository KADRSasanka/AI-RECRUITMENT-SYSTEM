using OrganizationEntity = server.Entities.Organization;
using server.Repositories.Interfaces;

namespace server.Features.Organization.Interfaces;

public interface IOrganizationRepository
    : IBaseRepository<OrganizationEntity>
{
}