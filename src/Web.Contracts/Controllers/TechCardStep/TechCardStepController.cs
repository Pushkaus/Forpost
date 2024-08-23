using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.TechCardSteps;
using Forpost.Web.Contracts.Models.TechCardSteps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.TechCardStep;
[ApiController]
[Route("api/v1/techcardstep")]
public sealed class TechCardStepController: ControllerBase
{
    private readonly ITechCardStepService _techCardStepService;
    private readonly IMapper _mapper;

    public TechCardStepController(ITechCardStepService techCardStepService, IMapper mapper)
    {
        _techCardStepService = techCardStepService;
        _mapper = mapper;
    }
    /// <summary>
    /// Получение всех этапов по Id тех.карты
    /// </summary>
    /// <param name="techCardId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<StepsInTechCardResponse>),StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<StepsInTechCardResponse>> GetStepsByTechCardIdAsync(Guid techCardId,
        CancellationToken cancellationToken)
    {
        var model = await _techCardStepService.GetStepsByTechCardIdAsync(techCardId, cancellationToken);
        var result = _mapper.Map<IReadOnlyCollection<StepsInTechCardResponse>>(model);
        return result;
    }
    /// <summary>
    /// Добавление этапа в тех.карту
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<Guid> CreateAsync(TechCardStepRequest model, CancellationToken cancellationToken)
    {
        var techCardStep = _mapper.Map<TechCardStepCreateModel>(model);
        return await _techCardStepService.AddAsync(techCardStep, cancellationToken);
    }
    /// <summary>
    /// Удаление этапа
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _techCardStepService.DeleteByIdAsync(id, cancellationToken);
    }
}