using AutoMapper;
using Forpost.Business.Models.Accounts;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Models.Employee;

namespace Forpost.Business.Mappers;

internal sealed class AccountMappingProfile : Profile
{
    public AccountMappingProfile()
    {
        CreateMap<LoginUserModel, LoginModel>()
            .ValidateMemberList(MemberList.Destination);
        CreateMap<LoginUserModel, EmployeeWithRole>()
            .ValidateMemberList(MemberList.Destination);
    }
}