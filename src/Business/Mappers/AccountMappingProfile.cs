using AutoMapper;
using Forpost.Business.Models.Accounts;
using Forpost.Store.Entities;

namespace Forpost.Business.Mappers;

public sealed class AccountMappingProfile: Profile
{
    public AccountMappingProfile()
    {
        CreateMap<LoginUserModel, Employee>().ValidateMemberList(MemberList.Destination);
        CreateMap<RegisterUserModel, Employee>()
            .ForMember(x => x.Role, opt => opt.Ignore())
            .ValidateMemberList(MemberList.Destination);
    }
}