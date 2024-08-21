using AutoMapper;
using Forpost.Business.Models.TechCards;
using Forpost.Web.Contracts.Models.TechCards;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class TechCardMappingProfile: Profile
{
    public TechCardMappingProfile()
    {
        CreateMap<TechCardCreateRequest, TechCardCreateModel>().ValidateMemberList(MemberList.Destination);
    }
}