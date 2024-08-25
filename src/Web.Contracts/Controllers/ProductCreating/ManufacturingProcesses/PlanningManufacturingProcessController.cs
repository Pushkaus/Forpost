// using AutoMapper;
// using Forpost.Domain.ProductCreating.ManufacturingProcesses.Services.Abstract;
// using Forpost.Domain.ProductCreating.PlanningManufacturingProcessModel;
// using Forpost.Web.Contracts.Models.ProductCreating.PlanningManufacturingProcessModel;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Forpost.Web.Contracts.Controllers.ProductCreating.ManufacturingProcesses;
// [ApiController]
// [Route("api/v1/PlanningManufacturingProcesses")]
// public sealed class PlanningManufacturingProcessController: ControllerBase
// {
//     private readonly IManufacturingProcessPlanningService _manufacturingProcessPlanningService;
//
//     private readonly IMapper _mapper;
//     public PlanningManufacturingProcessController(
//         IManufacturingProcessPlanningService manufacturingProcessPlanningService,
//         IMapper mapper)
//     {
//         _manufacturingProcessPlanningService = manufacturingProcessPlanningService;
//         _mapper = mapper;
//     }
//
//     [HttpPost]
//     public async Task<IActionResult> Planning(Models.ProductCreating.PlanningManufacturingProcessModel.PlanningManufacturingProcess process, CancellationToken cancellationToken)
//     {
//         var model = _mapper.Map<PlanningManufacturingProcessCommand>(process);
//         await _manufacturingProcessPlanningService.Planning(model, cancellationToken);
//         return Ok(model);
//     }
// }