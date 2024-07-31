using AutoMapper;
using Forpost.Business.Models.SubProducts;
using Forpost.Store.Entities;

namespace Forpost.Business.Mappers;

public class SubProductMappingProfile: Profile
{
    public SubProductMappingProfile()
    {
        CreateMap<SubProductCreateModel, Component>().ValidateMemberList(MemberList.Destination);
        CreateMap<Component, SubProductModel>()
            .ForMember(dest => dest.DaughterName, opt => opt.MapFrom(src => src.DaughterProduct.Name))
            .ValidateMemberList(MemberList.Destination);
    }
}