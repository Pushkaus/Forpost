using AutoMapper;
using Forpost.Business.Models.Products;
using Forpost.Store.Entities;

namespace Forpost.Business.Mappers;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductCreateModel, Product>().ValidateMemberList(MemberList.Destination);
        CreateMap<ProductUpdateModel, Product>().ValidateMemberList(MemberList.Destination);
    }
}