using AutoMapper;
using Forpost.Business.Catalogs.Operations;
using Forpost.Web.Contracts.Models.Operations;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class OperationMappingProfile: Profile
{
    public OperationMappingProfile()
    {
        CreateMap<OperationRequest, Operation>().ValidateMemberList(MemberList.Destination);
    }
    
}