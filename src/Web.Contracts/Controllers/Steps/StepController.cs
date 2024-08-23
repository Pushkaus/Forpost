using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Steps;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Web.Contracts.Models.Steps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.Steps;
[ApiController]
[Route("v1/api/steps")]
public sealed class StepController: ControllerBase
{
    private readonly IStepService _stepService;
    private readonly IMapper _mapper;
    public StepController(IStepService stepService)
    {
        _stepService = stepService;
    }
    /// <summary>
    /// Получение этапа по Id 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Step), StatusCodes.Status200OK)]
    public async Task<Step?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _stepService.GetByIdAsync(id, cancellationToken);
    }
    /// <summary>
    /// Получение всех этапов
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<Step>), StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<Step>> GetAllAsync(CancellationToken cancellationToken)
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
        var model = _mapper.Map<StepCreateModel>(step);
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