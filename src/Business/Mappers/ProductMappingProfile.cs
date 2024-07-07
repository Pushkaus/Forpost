using AutoMapper;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Models.Products;

namespace Forpost.Web.Contracts.Mappers;

public class ProductMappingProfile: Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductCreateModel, Product>().ValidateMemberList(MemberList.Destination);
        CreateMap<ProductUpdateModel, Product>().ValidateMemberList(MemberList.Destination);
    }
}