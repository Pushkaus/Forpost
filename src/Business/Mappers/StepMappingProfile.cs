using AutoMapper;
using Forpost.Business.Models.Steps;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Mappers;

internal sealed class StepMappingProfile: Profile
{
    public StepMappingProfile()
    {
        CreateMap<StepCreateModel, StepEntity>().ValidateMemberList(MemberList.Destination);
    }
}