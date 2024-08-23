using AutoMapper;
using Forpost.Business.Models.CreatingProducts.PlanningManufacturingProcessModel;
using Forpost.Store.Entities.ProductCreating;

namespace Forpost.Business.Mappers.CreatingProducts;

internal sealed class PlanningManufacturingProcessMappingProfile: Profile
{
    public PlanningManufacturingProcessMappingProfile()
    {
        CreateMap<PlanningManufacturingProcessModel, ManufacturingProcess>()
            .ValidateMemberList(MemberList.Source);
        CreateMap<StartingIssueModel, Issue>().ValidateMemberList(MemberList.Source);
    }
}