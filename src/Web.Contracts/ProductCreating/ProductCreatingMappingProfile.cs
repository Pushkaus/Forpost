using AutoMapper;
using Forpost.Application.Contracts.Catalogs.Employees;
using Forpost.Application.Contracts.Catalogs.TechCards;
using Forpost.Application.Contracts.ProductCreating.ManufacturingProcesses;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.Catalogs.Operations;
using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.Catalogs.TechCardItems;
using Forpost.Domain.Catalogs.TechCardSteps;
using Forpost.Features.Catalogs.Operations;
using Forpost.Features.Catalogs.Products;
using Forpost.Features.Catalogs.Steps;
using Forpost.Features.Catalogs.Storages;
using Forpost.Features.Catalogs.TechCardItems;
using Forpost.Features.Catalogs.TechCards;
using Forpost.Features.Catalogs.TechCardSteps;
using Forpost.Web.Contracts.Catalogs.Contractors;
using Forpost.Web.Contracts.Catalogs.Empoyees;
using Forpost.Web.Contracts.Catalogs.Operations;
using Forpost.Web.Contracts.Catalogs.Products;
using Forpost.Web.Contracts.Catalogs.Steps;
using Forpost.Web.Contracts.Catalogs.Storages;
using Forpost.Web.Contracts.Catalogs.TechCardItems;
using Forpost.Web.Contracts.Catalogs.TechCards;
using Forpost.Web.Contracts.Catalogs.TechCardSteps;
using Forpost.Web.Contracts.ProductCreating;

namespace Forpost.Web.Contracts.Catalogs;

internal sealed class ProductCreatingMappingProfile : Profile
{
    public ProductCreatingMappingProfile()
    {
        CreateMap<ManufacturingProcessWithDetailsModel, ManufacturingProcessResponse>(MemberList.Destination);
    }
}