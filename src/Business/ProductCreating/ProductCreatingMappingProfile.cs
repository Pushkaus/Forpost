using AutoMapper;
using Forpost.Business.ProductCreating.PlanningManufacturingProcessModel;
using Forpost.Store.Entities.ProductCreating;

namespace Forpost.Business.ProductCreating;

internal sealed class ProductCreatingMappingProfile : Profile
{
    public ProductCreatingMappingProfile()
    {
        CreateMap<PlanningManufacturingProcessCommand, ManufacturingProcessEntity>()
            .ValidateMemberList(MemberList.Source);
        CreateMap<StartingIssueCommand, IssueEntity>().ValidateMemberList(MemberList.Source);
    }
}