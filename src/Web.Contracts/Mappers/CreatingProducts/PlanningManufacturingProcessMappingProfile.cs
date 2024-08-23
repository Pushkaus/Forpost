using AutoMapper;
using Forpost.Business.Models.CreatingProducts.LaunchManufacturingProcessModel;
using Forpost.Business.Models.CreatingProducts.PlanningManufacturingProcessModel;
using Forpost.Store.Entities.ProductCreating;
using Forpost.Web.Contracts.Models.CreatingProducts.PlanningManufacturingProcessModel;

namespace Forpost.Web.Contracts.Mappers.CreatingProducts;

internal sealed class PlanningManufacturingProcessMappingProfile: Profile
{
    public PlanningManufacturingProcessMappingProfile()
    {
        CreateMap<PlanningManufacturingProcess, PlanningManufacturingProcessModel>()
            .ValidateMemberList(MemberList.Source);
        CreateMap<StartingIssue, StartingIssueModel>().ValidateMemberList(MemberList.Source);
    }
}