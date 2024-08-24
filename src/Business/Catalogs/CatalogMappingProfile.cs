using AutoMapper;
using Forpost.Business.Catalogs.Operations;
using Forpost.Business.Catalogs.Products.Commands;
using Forpost.Business.Catalogs.Steps;
using Forpost.Business.Catalogs.Storages;
using Forpost.Business.Catalogs.TechCardItems;
using Forpost.Business.Catalogs.TechCards;
using Forpost.Business.Catalogs.TechCardSteps;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Models.TechCardItem;
using Forpost.Store.Repositories.Models.TechCardStep;

namespace Forpost.Business.Catalogs;

internal sealed class CatalogMappingProfile : Profile
{
    public CatalogMappingProfile()
    {
        MapStorages();
        MapTechCardSteps();
        MapTechCards();
        MapTechCardItems();
        MapSteps();
        MapProducts();
        MapOperations();
    }

    private void MapStorages()
    {
        CreateMap<StorageCreateCommand, StorageEntity>().ValidateMemberList(MemberList.Destination);
    }

    private void MapTechCardSteps()
    {
        CreateMap<StepsInTechCardModel, StepsInTechCard>().ValidateMemberList(MemberList.Destination);
        CreateMap<TechCardStepCreateCommand, TechCardStepEntity>().ValidateMemberList(MemberList.Source);
    }

    private void MapTechCards()
    {
        CreateMap<TechCardCreateCommand, TechCardEntity>().ValidateMemberList(MemberList.Source);
    }

    private void MapTechCardItems()
    {
        CreateMap<ItemsInTechCardModel, ItemsInTechCard>().ValidateMemberList(MemberList.Destination);
    }

    private void MapSteps()
    {
        CreateMap<StepCreateCommand, StepEntity>().ValidateMemberList(MemberList.Destination);
    }

    private void MapProducts()
    {
        CreateMap<ProductCreateCommand, ProductEntity>().ValidateMemberList(MemberList.Destination);
        CreateMap<ProductUpdateCommand, ProductEntity>().ValidateMemberList(MemberList.Destination);
    }

    private void MapOperations()
    {
        CreateMap<Operation, OperationEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ValidateMemberList(MemberList.Destination);
    }


}