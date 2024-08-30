using AutoMapper;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.Catalogs.Operations;
using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.Catalogs.Storages;
using Forpost.Domain.Catalogs.TechCards;
using Forpost.Domain.Catalogs.TechCardSteps;
using Forpost.Features.Catalogs.Contractors;
using Forpost.Features.Catalogs.Operations;
using Forpost.Features.Catalogs.Products;
using Forpost.Features.Catalogs.Steps;
using Forpost.Features.Catalogs.Storages;
using Forpost.Features.Catalogs.TechCards;
using Forpost.Features.Catalogs.TechCardSteps;

namespace Forpost.Features.Catalogs;

internal sealed class CatalogMappingProfile : Profile
{
    public CatalogMappingProfile()
    {
        MapStorages();
        MapTechCardSteps();
        MapTechCards();
        MapSteps();
        MapProducts();
        MapOperations();
    }

    private void MapStorages()
    {
        CreateMap<AddStorageCommand, Storage>().ValidateMemberList(MemberList.Destination);
        CreateMap<AddContractorCommand, Contractor>().ValidateMemberList(MemberList.Destination);
    }

    private void MapTechCardSteps()
    {
        CreateMap<TechCardStepCreateCommand, TechCardStep>().ValidateMemberList(MemberList.Source);
    }

    private void MapTechCards()
    {
        CreateMap<AddTechCardCommand, TechCard>().ValidateMemberList(MemberList.Source);
    }

    private void MapSteps()
    {
        CreateMap<AddStepCommand, Step>().ValidateMemberList(MemberList.Destination);
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
}