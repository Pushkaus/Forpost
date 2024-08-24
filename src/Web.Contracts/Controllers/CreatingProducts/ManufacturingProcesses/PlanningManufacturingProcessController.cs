using AutoMapper;
using Forpost.Business.ProductCreating.ManufacturingProcesses.Services.Abstract;
using Forpost.Business.ProductCreating.PlanningManufacturingProcessModel;
using Forpost.Web.Contracts.Models.CreatingProducts.PlanningManufacturingProcessModel;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.CreatingProducts.ManufacturingProcesses;
[ApiController]
[Route("api/v1/PlanningManufacturingProcesses")]
public sealed class PlanningManufacturingProcessController: ControllerBase
{
    private readonly IManufacturingProcessPlanningService _manufacturingProcessPlanningService;

    private readonly IMapper _mapper;
    public PlanningManufacturingProcessController(
        IManufacturingProcessPlanningService manufacturingProcessPlanningService,
        IMapper mapper)
    {
        _manufacturingProcessPlanningService = manufacturingProcessPlanningService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Planning(Models.CreatingProducts.PlanningManufacturingProcessModel.PlanningManufacturingProcess process, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<PlanningManufacturingProcessCommand>(process);
        await _manufacturingProcessPlanningService.Planning(model, cancellationToken);
        return Ok(model);
    }
}