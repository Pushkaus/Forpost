using AutoMapper;
using Forpost.Application.Contracts.Catalogs.Employees;
using Forpost.Domain.Catalogs.Category;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.Catalogs.Contractors.ContractorRepresentatives;
using Forpost.Domain.Catalogs.Employees;
using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.Catalogs.Roles;
using Forpost.Domain.Catalogs.Storages;
using Forpost.Domain.Catalogs.TechCards;
using Forpost.Domain.Catalogs.TechCards.Operations;
using Forpost.Domain.Catalogs.TechCards.TechCardItems;
using Forpost.Domain.Catalogs.TechCards.TechCardOperations;
using Forpost.Features.Auth;
using Forpost.Features.Catalogs.Categories;
using Forpost.Features.Catalogs.Contractors;
using Forpost.Features.Catalogs.Contractors.ContractorRepresentatives;
using Forpost.Features.Catalogs.Employees;
using Forpost.Features.Catalogs.Products;
using Forpost.Features.Catalogs.Roles;
using Forpost.Features.Catalogs.Storages;
using Forpost.Features.Catalogs.TechCards;
using Forpost.Features.Catalogs.TechCards.Operations;
using Forpost.Features.Catalogs.TechCards.TechCardItems;
using Forpost.Features.Catalogs.TechCards.TechCardOperations;

namespace Forpost.Features.Catalogs;

internal sealed class CatalogMappingProfile : Profile
{
    public CatalogMappingProfile()
    {
        MapStorages();
        MapTechCardSteps();
        MapTechCards();
        MapProducts();
        MapOperations();
        MapAuth();
        MapContractor();
        MapCategory();
        MapEmployee();
    }

    private void MapStorages()
    {
        CreateMap<AddStorageCommand, Storage>().ValidateMemberList(MemberList.Destination);
        CreateMap<UpdateStorageCommand, Storage>().ValidateMemberList(MemberList.Destination);
    }

    private void MapEmployee()
    {
        CreateMap<UpdateEmployeeCommand, Employee>()
            .ForMember(entity => entity.PasswordHash, opt => opt.Ignore())
            .ValidateMemberList(MemberList.Destination);
        CreateMap<AddRoleCommand, Role>().ValidateMemberList(MemberList.Destination);
    }

    private void MapCategory()
    {
        CreateMap<UpdateCategoryCommand, Category>().ValidateMemberList(MemberList.Destination);
    }

    private void MapContractor()
    {
        CreateMap<AddContractorCommand, Contractor>().ValidateMemberList(MemberList.Destination);
        CreateMap<UpdateContractorCommand, Contractor>().ValidateMemberList(MemberList.Destination);
        CreateMap<AddContractorRepresentativeCommand, ContractorRepresentative>()
            .ValidateMemberList(MemberList.Destination);
        CreateMap<UpdateContractorRepresentativeByIdCommand, ContractorRepresentative>(MemberList.Destination)
            .ValidateMemberList(MemberList.Destination);
    }

    private void MapTechCardSteps()
    {
        CreateMap<TechCardOperationCreateCommand, TechCardOperation>().ValidateMemberList(MemberList.Destination);
        CreateMap<UpdateTechCardOperationCommand, TechCardOperation>().ValidateMemberList(MemberList.Destination);
    }

    private void MapTechCards()
    {
        CreateMap<AddTechCardCommand, TechCard>().ValidateMemberList(MemberList.Destination);
        CreateMap<AddTechCardItemCommand, TechCardItem>().ValidateMemberList(MemberList.Destination);
        CreateMap<UpdateTechCardCommand, TechCard>().ValidateMemberList(MemberList.Destination);
        CreateMap<UpdateTechCardItemCommand, TechCardItem>().ValidateMemberList(MemberList.Destination);
    }

    private void MapProducts()
    {
        CreateMap<AddProductCommand, Product>().ValidateMemberList(MemberList.Destination);
        CreateMap<UpdateProductCommand, Product>().ValidateMemberList(MemberList.Destination);
    }

    private void MapOperations()
    {
        CreateMap<AddOperationCommand, Operation>().ValidateMemberList(MemberList.Destination);
    }

    private void MapAuth()
    {
        CreateMap<LoginUserCommand, EmployeeWithRoleModel>().ValidateMemberList(MemberList.Destination);
    }
}