using AutoMapper;
using Forpost.Business.Models.TechCardItems;
using Forpost.Store.Repositories.Models.TechCardItem;

namespace Forpost.Business.Mappers;

internal sealed class TechCardItemMappingProfile: Profile
{
    internal TechCardItemMappingProfile()
    {
        CreateMap<ItemsInTechCard, ItemsInTechCardModel>().ValidateMemberList(MemberList.Destination);
    }
}