// using AutoMapper;
// using Forpost.Business.ProductCreating.PlanningManufacturingProcessModel;
// using Forpost.Business.Sortout;
// using Forpost.Store.Entities.ProductCreating;
//
// namespace Forpost.Business.ProductCreating;
//
// internal sealed class ProductCreatingMappingProfile : Profile
// {
//     public ProductCreatingMappingProfile()
//     {
//         CreateMap<PlanningManufacturingProcessCommand, ManufacturingProcess>()
//             .ValidateMemberList(MemberList.Source);
//         CreateMap<StartingIssueCommand, Issue>().ValidateMemberList(MemberList.Source);
//     }
// }