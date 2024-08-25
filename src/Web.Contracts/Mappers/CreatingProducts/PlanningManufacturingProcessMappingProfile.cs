// using AutoMapper;
// using Forpost.Domain.ProductCreating.PlanningManufacturingProcessModel;
// using Forpost.Web.Contracts.Models.CreatingProducts.PlanningManufacturingProcessModel;
//
// namespace Forpost.Web.Contracts.Mappers.CreatingProducts;
//
// internal sealed class PlanningManufacturingProcessMappingProfile: Profile
// {
//     public PlanningManufacturingProcessMappingProfile()
//     {
//         CreateMap<Models.CreatingProducts.PlanningManufacturingProcessModel.PlanningManufacturingProcess, PlanningManufacturingProcessCommand>()
//             .ValidateMemberList(MemberList.Source);
//         CreateMap<Models.CreatingProducts.PlanningManufacturingProcessModel.StartingIssue, StartingIssueCommand>().ValidateMemberList(MemberList.Source);
//     }
// }