using AutoMapper;
using Forpost.Business.Models.TechCardSteps;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Models.TechCardStep;

namespace Forpost.Business.Mappers;

internal sealed class TechCardStepMappingProfile: Profile
{
    internal TechCardStepMappingProfile()
    {
        CreateMap<StepsInTechCard, StepsInTechCardModel>().ValidateMemberList(MemberList.Destination);
    }
}