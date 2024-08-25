using AutoMapper;
using Forpost.Application.Catalogs.TechCards;
using Forpost.Domain.Catalogs.TechCardItems;
using Forpost.Domain.Catalogs.TechCards;
using Forpost.Web.Contracts.Models.TechCards;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class TechCardMappingProfile : Profile
{
    public TechCardMappingProfile()
    {
        CreateMap<TechCardCreateRequest, AddTechCardCommand>().ValidateMemberList(MemberList.Destination);
    }
}