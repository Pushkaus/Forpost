using AutoMapper;
using Forpost.Application.Catalogs.Operations;
using Forpost.Application.Contracts.ProductsDevelopments;
using Forpost.Web.Contracts.Catalogs.Operations;

namespace Forpost.Web.Contracts.ProductCreating;

internal sealed class CreatingProductMappingProfile : Profile
{
    public CreatingProductMappingProfile()
    {
        CreateMap<LocationDeterminationProduct, LocationDeterminationProductModel>()
            .ValidateMemberList(MemberList.Destination);  
    }
}