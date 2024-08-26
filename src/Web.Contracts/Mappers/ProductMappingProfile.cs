using AutoMapper;
using Forpost.Application.Catalogs.Products;
using Forpost.Web.Contracts.Models.Products;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductCreateRequest, AddProductCommand>().ValidateMemberList(MemberList.Destination);
        CreateMap<ProductUpdateRequest, UpdateProductCommand>().ValidateMemberList(MemberList.Destination);
    }
}