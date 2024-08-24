using AutoMapper;
using Forpost.Business.Catalogs.TechCardSteps;
using Forpost.Web.Contracts.Models.TechCardSteps;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class TechCardStepMappingProfile: Profile
{
    public TechCardStepMappingProfile()
    {
        CreateMap<StepsInTechCard, StepsInTechCardResponse>().ValidateMemberList(MemberList.Destination);
        CreateMap<TechCardStepRequest, TechCardStepCreateCommand>().ValidateMemberList(MemberList.Destination);
    }
}