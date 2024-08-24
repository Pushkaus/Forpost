using AutoMapper;
using Forpost.Business.Models.TechCardSteps;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Models.TechCardStep;

namespace Forpost.Business.Mappers;

internal sealed class TechCardStepMappingProfile: Profile
{
    public TechCardStepMappingProfile()
    {
        CreateMap<StepsInTechCard, StepsInTechCardModel>().ValidateMemberList(MemberList.Destination);
        CreateMap<TechCardStepCreateModel, TechCardStepEntity>().ValidateMemberList(MemberList.Source);
    }
}