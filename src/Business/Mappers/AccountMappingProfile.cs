using AutoMapper;
using Forpost.Business.Models.Accounts;
using Forpost.Store.Entities;

namespace Forpost.Web.Contracts.Mappers;

public sealed class AccountMappingProfile: Profile
{
    public AccountMappingProfile()
    {
        CreateMap<LoginUserModel, Employee>().ValidateMemberList(MemberList.Destination);
        CreateMap<RegisterUserModel, Employee>().ValidateMemberList(MemberList.Destination);
    }
}