using AutoMapper;
using server.Entities;
using server.Features.Organization.DTOs;
using server.Features.Department.DTOs;

namespace server.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Organization, OrganizationResponse>();

        CreateMap<CreateOrganizationRequest, Organization>();

        CreateMap<UpdateOrganizationRequest, Organization>();

        CreateMap<Department, DepartmentResponse>()
            .ForMember(
                dest => dest.OrganizationName,
                opt => opt.MapFrom(src => src.Organization.OrganizationName));

        CreateMap<CreateDepartmentRequest, Department>();

        CreateMap<UpdateDepartmentRequest, Department>();
    }
}