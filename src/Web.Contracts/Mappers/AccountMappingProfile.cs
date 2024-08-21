using AutoMapper;
using Forpost.Business.Models.Accounts;
using Forpost.Web.Contracts.Models.Accounts;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class AccountMappingProfile : Profile
{
    public AccountMappingProfile()
    {
        CreateMap<LoginUserRequest, LoginUserModel>().ValidateMemberList(MemberList.Destination);
        CreateMap<RegisterUserRequest, RegisterUserModel>().ValidateMemberList(MemberList.Destination);
    }
}