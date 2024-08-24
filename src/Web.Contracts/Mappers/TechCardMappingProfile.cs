using AutoMapper;
using Forpost.Business.Catalogs.TechCardItems;
using Forpost.Business.Catalogs.TechCards;
using Forpost.Store.Entities.Catalog;
using Forpost.Web.Contracts.Models.TechCards;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class TechCardMappingProfile: Profile
{
    public TechCardMappingProfile()
    {
        CreateMap<TechCardCreateRequest, TechCardCreateCommand>().ValidateMemberList(MemberList.Destination);
        CreateMap<TechCardItemCreateCommand, TechCardItemEntity>().ValidateMemberList(MemberList.Destination);
    }
}