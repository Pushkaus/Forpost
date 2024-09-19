using AutoMapper;
using Forpost.Application.Contracts.ProductCreating.ManufacturingProcesses;
using Forpost.Application.Contracts.ProductCreating.ProductsDevelopments;

namespace Forpost.Web.Contracts.ProductCreating;

internal sealed class ProductCreatingMappingProfile : Profile
{
    public ProductCreatingMappingProfile()
    {
        CreateMap<ManufacturingProcessWithDetailsModel, ManufacturingProcessResponse>().ValidateMemberList(MemberList.Source);
        CreateMap<ProductDevelopmentModel, ProductDevelopmentResponse>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.StatusRead))
            .ValidateMemberList(MemberList.Destination);
    }
}