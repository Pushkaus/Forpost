using AutoMapper;
using Forpost.Application.Catalogs.Operations;
using Forpost.Application.Catalogs.Products;
using Forpost.Application.Catalogs.Steps;
using Forpost.Application.Catalogs.Storages;
using Forpost.Application.Catalogs.TechCardItems;
using Forpost.Application.Catalogs.TechCards;
using Forpost.Application.Catalogs.TechCardSteps;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.Catalogs.Operations;
using Forpost.Domain.Catalogs.TechCardItems;
using Forpost.Domain.Catalogs.TechCardSteps;
using Forpost.Web.Contracts.Catalogs.Contractors;
using Forpost.Web.Contracts.Catalogs.Operations;
using Forpost.Web.Contracts.Catalogs.Products;
using Forpost.Web.Contracts.Catalogs.Steps;
using Forpost.Web.Contracts.Catalogs.Storages;
using Forpost.Web.Contracts.Catalogs.TechCardItems;
using Forpost.Web.Contracts.Catalogs.TechCards;
using Forpost.Web.Contracts.Catalogs.TechCardSteps;

namespace Forpost.Web.Contracts.Catalogs;

internal sealed class CatalogMappingProfile : Profile
{
    public CatalogMappingProfile()
    {
        CreateMap<Contractor, ContractorResponse>().ValidateMemberList(MemberList.Destination);
        
        CreateMap<TechCardStep, StepsInTechCardResponse>().ValidateMemberList(MemberList.Destination);
        CreateMap<TechCardStepRequest, TechCardStepCreateCommand>().ValidateMemberList(MemberList.Destination);
        
        CreateMap<TechCardCreateRequest, AddTechCardCommand>().ValidateMemberList(MemberList.Destination);
        
        CreateMap<TechCardItem, TechCardItemsResponse>().ValidateMemberList(MemberList.Destination);
        CreateMap<TechCardItemRequest, AddTechCardItemCommand>().ValidateMemberList(MemberList.Destination);
        
        CreateMap<StorageCreateRequest, AddStorageCommand>().ValidateMemberList(MemberList.Destination);
        
        CreateMap<StepCreateRequest, AddStepCommand>().ValidateMemberList(MemberList.Destination);
        
        CreateMap<OperationRequest, Operation>().ValidateMemberList(MemberList.Destination);
        
        CreateMap<ProductCreateRequest, AddProductCommand>().ValidateMemberList(MemberList.Destination);
        CreateMap<ProductUpdateRequest, UpdateProductCommand>().ValidateMemberList(MemberList.Destination);
        
        CreateMap<OperationCreateRequest, AddOperationCommand>().ValidateMemberList(MemberList.Destination);
        
    }
}