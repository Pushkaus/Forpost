using AutoMapper;
using Forpost.Business.Auth.Commands;
using Forpost.Store.Repositories.Models.Employee;

namespace Forpost.Business.Auth;

internal sealed class AccountMappingProfile : Profile
{
    public AccountMappingProfile()
    {
        CreateMap<LoginUserCommand, LoginModel>()
            .ValidateMemberList(MemberList.Destination);
        CreateMap<LoginUserCommand, EmployeeWithRoleModel>()
            .ValidateMemberList(MemberList.Destination);
    }
}