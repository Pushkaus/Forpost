using AutoMapper;
using Forpost.Business.Models.TechCardItems;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Web.Contracts.Models.TechCardItems;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class TechCardItemsMappingProfile: Profile
{
    public TechCardItemsMappingProfile()
    {
        CreateMap<ItemsInTechCardModel, TechCardItemsResponse>().ValidateMemberList(MemberList.Destination);
        CreateMap<TechCardItemRequest, TechCardItemCreateModel>().ValidateMemberList(MemberList.Destination);
    }
}