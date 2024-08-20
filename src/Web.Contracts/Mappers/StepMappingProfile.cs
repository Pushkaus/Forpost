using AutoMapper;
using Forpost.Business.Models.Steps;
using Forpost.Store.Entities;
using Forpost.Web.Contracts.Models.Steps;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class StepMappingProfile: Profile
{
    internal StepMappingProfile()
    {
        CreateMap<StepCreateRequest, StepCreateModel>().ValidateMemberList(MemberList.Destination);
    }
}