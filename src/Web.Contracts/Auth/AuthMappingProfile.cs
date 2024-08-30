using AutoMapper;
using Forpost.Application.Contracts.Catalogs.Employees;
using Forpost.Features.Auth;

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