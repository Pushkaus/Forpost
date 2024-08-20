using AutoMapper;
using Forpost.Business.Models.TechCardItems;
using Forpost.Store.Entities;
using Forpost.Web.Contracts.Models.TechCardItems;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class TechCardItemsMappingProfile: Profile
{
    internal TechCardItemsMappingProfile()
    {
        CreateMap<ItemsInTechCardModel, TechCardItemsResponse>().ValidateMemberList(MemberList.Destination);
        CreateMap<TechCardItem, TechCardItemCreateModel>().ValidateMemberList(MemberList.Destination);
    }
}