using AutoMapper;
using Forpost.Business.ProductCreating.PlanningManufacturingProcessModel;
using Forpost.Store.Entities.ProductCreating;
using Forpost.Web.Contracts.Models.CreatingProducts.PlanningManufacturingProcessModel;

namespace Forpost.Web.Contracts.Mappers.CreatingProducts;

internal sealed class PlanningManufacturingProcessMappingProfile: Profile
{
    public PlanningManufacturingProcessMappingProfile()
    {
        CreateMap<Models.CreatingProducts.PlanningManufacturingProcessModel.PlanningManufacturingProcess, PlanningManufacturingProcessCommand>()
            .ValidateMemberList(MemberList.Source);
        CreateMap<Models.CreatingProducts.PlanningManufacturingProcessModel.StartingIssue, StartingIssueCommand>().ValidateMemberList(MemberList.Source);
    }
}