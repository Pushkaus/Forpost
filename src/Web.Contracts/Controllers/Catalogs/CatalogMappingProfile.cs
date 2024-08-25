using AutoMapper;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Web.Contracts.Models.Contragents;

namespace Forpost.Web.Contracts.Controllers.Catalogs;

internal sealed class CatalogMappingProfile : Profile
{
    public CatalogMappingProfile()
    {
        CreateMap<Contractor, ContractorResponse>().ValidateMemberList(MemberList.Destination);
    }
}