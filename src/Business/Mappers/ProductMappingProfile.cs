using AutoMapper;
using Forpost.Business.Models.Products;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Mappers;

internal sealed class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductCreateModel, ProductEntity>().ValidateMemberList(MemberList.Destination);
        CreateMap<ProductUpdateModel, ProductEntity>().ValidateMemberList(MemberList.Destination);
    }
}