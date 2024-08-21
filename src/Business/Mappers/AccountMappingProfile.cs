using AutoMapper;
using Forpost.Business.Models.Accounts;
using Forpost.Store.Repositories.Models.Employee;

namespace Forpost.Business.Mappers;

internal sealed class AccountMappingProfile : Profile
{
    public AccountMappingProfile()
    {
        CreateMap<LoginUserModel, EmployeeWithRole>().ValidateMemberList(MemberList.Destination);
        /*CreateMap<RegisterUserModel, Employee>()
            .ForMember(x => x.Role, opt => opt.Ignore())
            .ValidateMemberList(MemberList.Destination);*/
    }
}