using AutoMapper;
using Forpost.Application.Auth;
using Forpost.Web.Contracts.Models.Accounts;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class AccountMappingProfile : Profile
{
    public AccountMappingProfile()
    {
        CreateMap<LoginUserRequest, LoginUserCommand>().ValidateMemberList(MemberList.Destination);
        CreateMap<RegisterUserRequest, RegisterUserCommand>().ValidateMemberList(MemberList.Destination);
    }
}