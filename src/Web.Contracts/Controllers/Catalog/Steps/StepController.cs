using AutoMapper;
using Forpost.Business.Catalogs.Steps;
using Forpost.Store.Entities.Catalog;
using Forpost.Web.Contracts.Models.Steps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.Catalog.Steps;
[ApiController]
[Route("v1/api/steps")]
public sealed class StepController: ControllerBase
{
    private readonly IStepService _stepService;
    private readonly IMapper _mapper;
    public StepController(IStepService stepService, IMapper mapper)
    {
        _stepService = stepService;
        _mapper = mapper;
    }
    /// <summary>
    /// Получение этапа по Id 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(StepEntity), StatusCodes.Status200OK)]
    public async Task<StepEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _stepService.GetByIdAsync(id, cancellationToken);
    }
    /// <summary>
    /// Получение всех этапов
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<StepEntity>), StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<StepEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _stepService.GetAllAsync(cancellationToken);
    }
    /// <summary>
    /// Создание этапа
    /// </summary>
    /// <param name="step"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<Guid> CreateAsync([FromBody] StepCreateRequest step, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<StepCreateCommand>(step);
        return await _stepService.AddAsync(model, cancellationToken);
    }
    /// <summary>
    /// Удаление этапа
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    [HttpDelete("{id}")]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _stepService.DeleteByIdAsync(id, cancellationToken);
    }
}