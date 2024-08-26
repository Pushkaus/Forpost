using AutoMapper;
using Forpost.Application.Catalogs.Steps;
using Forpost.Domain.Catalogs.Steps;
using Forpost.Web.Contracts.Models.Steps;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class StepMappingProfile : Profile
{
    public StepMappingProfile()
    {
        CreateMap<StepCreateRequest, AddStepCommand>().ValidateMemberList(MemberList.Destination);
    }
}