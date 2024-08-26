using AutoMapper;
using Forpost.Application.Auth;
using Forpost.Application.Contracts.Catalogs.Employees;
using Forpost.Web.Contracts.Models.Accounts;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class AccountMappingProfile : Profile
{
    public AccountMappingProfile()
    {
        CreateMap<LoginUserRequest, LoginUserCommand>().ValidateMemberList(MemberList.Destination);
        CreateMap<RegisterUserRequest, RegisterUserModel>().ValidateMemberList(MemberList.Source);
        CreateMap<RegisterUserRequest, RegisterUserCommand>().ValidateMemberList(MemberList.Destination);
    }
}