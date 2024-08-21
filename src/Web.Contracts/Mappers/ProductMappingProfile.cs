using AutoMapper;
using Forpost.Business.Models.Products;
using Forpost.Web.Contracts.Models.Products;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductCreateRequest, ProductCreateModel>().ValidateMemberList(MemberList.Destination);
        CreateMap<ProductUpdateRequest, ProductUpdateModel>().ValidateMemberList(MemberList.Destination);
    }
}