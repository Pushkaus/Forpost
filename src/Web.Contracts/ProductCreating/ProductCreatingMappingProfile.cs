using AutoMapper;
using Forpost.Application.Contracts.ProductCreating.ManufacturingProcesses;

namespace Forpost.Web.Contracts.ProductCreating;

internal sealed class ProductCreatingMappingProfile : Profile
{
    public ProductCreatingMappingProfile()
    {
        CreateMap<ManufacturingProcessWithDetailsModel, ManufacturingProcessResponse>(MemberList.Source);
    }
}