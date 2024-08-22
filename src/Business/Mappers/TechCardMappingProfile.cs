using AutoMapper;
using Forpost.Business.Models.TechCards;
using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Mappers;

internal sealed class TechCardMappingProfile: Profile
{
    public TechCardMappingProfile()
    {
        CreateMap<TechCardCreateModel, TechCard>().ValidateMemberList(MemberList.Source);
    }
}