using AutoMapper;
using Forpost.Application.Catalogs.TechCardSteps;
using Forpost.Domain.Catalogs.TechCardSteps;
using Forpost.Web.Contracts.Models.TechCardSteps;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class TechCardStepMappingProfile : Profile
{
    public TechCardStepMappingProfile()
    {
        CreateMap<TechCardStep, StepsInTechCardResponse>().ValidateMemberList(MemberList.Destination);
        CreateMap<TechCardStepRequest, TechCardStepCreateCommand>().ValidateMemberList(MemberList.Destination);
    }
}