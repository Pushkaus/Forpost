using AutoMapper;
using Forpost.Business.Models.TechCardSteps;
using Forpost.Web.Contracts.Models.TechCardSteps;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class TechCardStepMappingProfile: Profile
{
    internal TechCardStepMappingProfile()
    {
        CreateMap<StepsInTechCardModel, StepsInTechCardResponse>().ValidateMemberList(MemberList.Destination);
        CreateMap<TechCardStepRequest, TechCardStepCreateModel>().ValidateMemberList(MemberList.Destination);
    }
}