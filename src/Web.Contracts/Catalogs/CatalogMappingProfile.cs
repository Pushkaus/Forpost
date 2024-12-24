using AutoMapper;
using Forpost.Application.Contracts.Catalogs.Employees;
using Forpost.Application.Contracts.Catalogs.TechCards;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.Catalogs.TechCards.Operations;
using Forpost.Domain.Catalogs.TechCards.TechCardItems;
using Forpost.Domain.Catalogs.TechCards.TechCardOperations;
using Forpost.Features.Catalogs.Products;
using Forpost.Features.Catalogs.Storages;
using Forpost.Features.Catalogs.TechCards;
using Forpost.Features.Catalogs.TechCards.Operations;
using Forpost.Features.Catalogs.TechCards.TechCardItems;
using Forpost.Features.Catalogs.TechCards.TechCardOperations;
using Forpost.Web.Contracts.Catalogs.Contractors;
using Forpost.Web.Contracts.Catalogs.Employees;
using Forpost.Web.Contracts.Catalogs.Operations;
using Forpost.Web.Contracts.Catalogs.Products;
using Forpost.Web.Contracts.Catalogs.Storages;
using Forpost.Web.Contracts.Catalogs.TechCardItems;
using Forpost.Web.Contracts.Catalogs.TechCardOperations;
using Forpost.Web.Contracts.Catalogs.TechCards;

namespace Forpost.Web.Contracts.Catalogs;

internal sealed class CatalogMappingProfile : Profile
{
    public CatalogMappingProfile()
    {
        CreateMap<Contractor, ContractorResponse>().ValidateMemberList(MemberList.Destination);
        CreateMap<EmployeeWithRoleModel, EmployeeResponse>().ValidateMemberList(MemberList.Destination);
        
        CreateMap<TechCardOperationRequest, TechCardOperationCreateCommand>().ValidateMemberList(MemberList.Destination);
        CreateMap<TechCardCreateRequest, AddTechCardCommand>().ValidateMemberList(MemberList.Destination);
        CreateMap<TechCardModel, TechCardResponse>().ValidateMemberList(MemberList.Destination);
        CreateMap<TechCardItem, TechCardItemsResponse>().ValidateMemberList(MemberList.Destination);
        CreateMap<TechCardItemRequest, AddTechCardItemCommand>().ValidateMemberList(MemberList.Destination);
        CreateMap<StorageCreateRequest, AddStorageCommand>().ValidateMemberList(MemberList.Destination);
        
        CreateMap<OperationRequest, Operation>().ValidateMemberList(MemberList.Destination);
        
        CreateMap<Product, ProductResponse>().ValidateMemberList(MemberList.Destination);
        
        CreateMap<ProductCreateRequest, AddProductCommand>().ValidateMemberList(MemberList.Destination);
        CreateMap<ProductUpdateRequest, UpdateProductCommand>().ValidateMemberList(MemberList.Destination);
        CreateMap<UpdateProductCommand, Product>().ValidateMemberList(MemberList.Destination);
        
        CreateMap<OperationCreateRequest, AddOperationCommand>().ValidateMemberList(MemberList.Destination);
        
        
        
    }
}