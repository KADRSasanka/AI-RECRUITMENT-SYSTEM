using OrganizationEntity = server.Entities.Organization;
using server.Data;
using server.Features.Organization.Interfaces;
using server.Repositories;

namespace server.Features.Organization.Repositories;

public class OrganizationRepository
    : BaseRepository<OrganizationEntity>, IOrganizationRepository
{
    public OrganizationRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    // Future custom Organization queries go here
    // Example:
    // public async Task<Organization?> GetByEmailAsync(string email)
    // {
    //     return await Context.Organizations
    //         .FirstOrDefaultAsync(o => o.Email == email);
    // }
}