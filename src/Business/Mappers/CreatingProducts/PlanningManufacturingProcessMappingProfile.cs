using AutoMapper;
using Forpost.Business.Models.CreatingProducts.PlanningManufacturingProcessModel;
using Forpost.Store.Entities.ProductCreating;

namespace Forpost.Business.Mappers.CreatingProducts;

internal sealed class PlanningManufacturingProcessMappingProfile: Profile
{
    public PlanningManufacturingProcessMappingProfile()
    {
        CreateMap<PlanningManufacturingProcessModel, ManufacturingProcessEntity>()
            .ValidateMemberList(MemberList.Source);
        CreateMap<StartingIssueModel, IssueEntity>().ValidateMemberList(MemberList.Source);
    }
}