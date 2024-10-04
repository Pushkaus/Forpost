using AutoMapper;
using Forpost.Application.Contracts.CRM.IssueHistory;

namespace Forpost.Web.Contracts.CRM;

internal sealed class CRM_MappingProfile: Profile
{
    public CRM_MappingProfile()
    {
        CreateMap<IssueHistoryRequest, IssueHistoryFilter>().ValidateMemberList(MemberList.Destination);
    }
}