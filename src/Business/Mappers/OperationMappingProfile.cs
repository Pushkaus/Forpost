using AutoMapper;
using Forpost.Business.Models.Operations;
using Forpost.Store.Entities;

namespace Forpost.Business.Mappers;

internal sealed class OperationMappingProfile: Profile
{
    public OperationMappingProfile()
    {
        CreateMap<OperationModel, Operation>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ValidateMemberList(MemberList.Destination);
    }
}