using AutoMapper;
using Forpost.Business.Catalogs.TechCardItems;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Web.Contracts.Models.TechCardItems;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class TechCardItemsMappingProfile: Profile
{
    public TechCardItemsMappingProfile()
    {
        CreateMap<ItemsInTechCard, TechCardItemsResponse>().ValidateMemberList(MemberList.Destination);
        CreateMap<TechCardItemRequest, TechCardItemCreateCommand>().ValidateMemberList(MemberList.Destination);
    }
}