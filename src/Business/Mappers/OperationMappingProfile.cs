using AutoMapper;
using Forpost.Business.Models.Operations;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Mappers;

internal sealed class OperationMappingProfile: Profile
{
    public OperationMappingProfile()
    {
        CreateMap<OperationModel, OperationEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ValidateMemberList(MemberList.Destination);
    }
}