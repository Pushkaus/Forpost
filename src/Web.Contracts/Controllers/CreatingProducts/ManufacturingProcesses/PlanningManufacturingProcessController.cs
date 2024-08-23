using AutoMapper;
using Forpost.Business.Abstract.Services.CreatingProducts;
using Forpost.Business.Models.CreatingProducts.PlanningManufacturingProcessModel;
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
    public async Task<IActionResult> Planning(PlanningManufacturingProcess process, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<PlanningManufacturingProcessModel>(process);
        await _manufacturingProcessPlanningService.Planning(model, cancellationToken);
        return Ok(model);
    }
}