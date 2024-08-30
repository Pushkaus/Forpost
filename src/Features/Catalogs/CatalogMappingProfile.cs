using AutoMapper;
using Forpost.Application.Catalogs.Contractors;
using Forpost.Application.Catalogs.Operations;
using Forpost.Application.Catalogs.Products;
using Forpost.Application.Catalogs.Steps;
using Forpost.Application.Catalogs.Storages;
using Forpost.Application.Catalogs.TechCards;
using Forpost.Application.Catalogs.TechCardSteps;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.Catalogs.Operations;
using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.Catalogs.Storages;
using Forpost.Domain.Catalogs.TechCards;
using Forpost.Domain.Catalogs.TechCardSteps;

namespace Forpost.Application.Catalogs;

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