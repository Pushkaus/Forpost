using AutoMapper;
using Forpost.Business.Catalogs.Products.Commands;
using Forpost.Web.Contracts.Models.Products;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductCreateRequest, ProductCreateCommand>().ValidateMemberList(MemberList.Destination);
        CreateMap<ProductUpdateRequest, ProductUpdateCommand>().ValidateMemberList(MemberList.Destination);
    }
}