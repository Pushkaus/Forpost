using AutoMapper;
using Forpost.Business.Models.Operations;
using Forpost.Web.Contracts.Models.Operations;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class OperationMappingProfile: Profile
{
    public OperationMappingProfile()
    {
        CreateMap<OperationRequest, OperationModel>().ValidateMemberList(MemberList.Destination);
    }
    
}