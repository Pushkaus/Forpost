using AutoMapper;
using Forpost.Business.Models.Accounts;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Models.Employee;
using EmployeeWithRoleModel = Forpost.Business.Models.Accounts.EmployeeWithRoleModel;

namespace Forpost.Business.Mappers;

public sealed class AccountMappingProfile: Profile
{
    public AccountMappingProfile()
    {
        CreateMap<LoginUserModel, EmployeeWithRole>().ValidateMemberList(MemberList.Destination);
        /*CreateMap<RegisterUserModel, Employee>()
            .ForMember(x => x.Role, opt => opt.Ignore())
            .ValidateMemberList(MemberList.Destination);*/
    }
}