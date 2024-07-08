using AutoMapper;
using Forpost.Business.Models.Products;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Models.Products;

namespace Forpost.Web.Contracts.Mappers;

public class ProductMappingProfile: Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductCreateRequest, ProductCreateModel>().ValidateMemberList(MemberList.Destination);
        CreateMap<ProductUpdateRequest, ProductUpdateModel>().ValidateMemberList(MemberList.Destination);
    }
}