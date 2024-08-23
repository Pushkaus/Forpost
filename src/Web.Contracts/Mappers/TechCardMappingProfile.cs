using AutoMapper;
using Forpost.Business.Models.TechCardItems;
using Forpost.Business.Models.TechCards;
using Forpost.Store.Entities.Catalog;
using Forpost.Web.Contracts.Models.TechCards;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class TechCardMappingProfile: Profile
{
    public TechCardMappingProfile()
    {
        CreateMap<TechCardCreateRequest, TechCardCreateModel>().ValidateMemberList(MemberList.Destination);
        CreateMap<TechCardItemCreateModel, TechCardItem>().ValidateMemberList(MemberList.Destination);
    }
}