using AutoMapper;
using Forpost.Business.Models.Products;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Mappers;

internal sealed class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductCreateModel, Product>().ValidateMemberList(MemberList.Destination);
        CreateMap<ProductUpdateModel, Product>().ValidateMemberList(MemberList.Destination);
    }
}