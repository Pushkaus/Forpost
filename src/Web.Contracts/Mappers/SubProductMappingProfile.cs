using AutoMapper;
using Forpost.Business.Models.SubProducts;
using Forpost.Web.Contracts.Models.SubProducts;

namespace Forpost.Web.Contracts.Mappers;

public sealed class SubProductMappingProfile: Profile
{
    public SubProductMappingProfile()
    {
        CreateMap<SubProductCreateRequest, SubProductCreateModel>().ValidateMemberList(MemberList.Destination);
        CreateMap<SubProductModel, SubProductResponse>().ValidateMemberList(MemberList.Destination);
    }
}