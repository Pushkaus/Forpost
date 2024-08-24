using AutoMapper;
using Forpost.Business.Catalogs.Steps;
using Forpost.Store.Entities;
using Forpost.Web.Contracts.Models.Steps;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class StepMappingProfile: Profile
{
    public StepMappingProfile()
    {
        CreateMap<StepCreateRequest, StepCreateCommand>().ValidateMemberList(MemberList.Destination);
    }
}