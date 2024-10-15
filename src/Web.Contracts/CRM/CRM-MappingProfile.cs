using AutoMapper;
using Forpost.Application.Contracts.CRM.IssueHistories;
using Forpost.Web.Contracts.CRM.IssueHistories;

namespace Forpost.Web.Contracts.CRM;

internal sealed class CRM_MappingProfile: Profile
{
    public CRM_MappingProfile()
    {
        CreateMap<IssueHistoryRequest, IssueHistoryFilter>().ValidateMemberList(MemberList.Destination);
    }
}