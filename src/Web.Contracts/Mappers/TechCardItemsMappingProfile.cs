using AutoMapper;
using Forpost.Application.Catalogs.TechCardItems;
using Forpost.Domain.Catalogs.TechCardItems;
using Forpost.Web.Contracts.Models.TechCardItems;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class TechCardItemsMappingProfile : Profile
{
    public TechCardItemsMappingProfile()
    {
        CreateMap<TechCardItem, TechCardItemsResponse>().ValidateMemberList(MemberList.Destination);
        CreateMap<TechCardItemRequest, AddTechCardItemCommand>().ValidateMemberList(MemberList.Destination);
    }
}