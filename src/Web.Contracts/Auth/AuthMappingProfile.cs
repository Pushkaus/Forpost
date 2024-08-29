using AutoMapper;
using Forpost.Application.Auth;
using Forpost.Application.Contracts.Catalogs.Employees;

namespace Forpost.Web.Contracts.Auth;

internal sealed class AuthMappingProfile : Profile
{
    public AuthMappingProfile()
    {
        CreateMap<LoginUserRequest, LoginUserCommand>().ValidateMemberList(MemberList.Destination);
        CreateMap<RegisterUserRequest, RegisterUserModel>().ValidateMemberList(MemberList.Source);
        CreateMap<RegisterUserRequest, RegisterUserCommand>().ValidateMemberList(MemberList.Destination);
    }
}