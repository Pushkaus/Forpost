using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.TechCards;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Web.Contracts.Models.TechCards;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.TechCardController;
[ApiController]
[Route("v1/api/techcard")]
public sealed class TechCardController: ControllerBase
{
    private readonly ITechCardService _techCardService;
    private readonly IMapper _mapper;

    public TechCardController(ITechCardService techCardService, IMapper mapper)
    {
        _techCardService = techCardService;
        _mapper = mapper;
    }
    /// <summary>
    /// Получение тех.карты по Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TechCard), StatusCodes.Status200OK)]
    public async Task<TechCard?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await _techCardService.GetByIdAsync(id, cancellationToken);
    /// <summary>
    /// Получение всех тех.карт
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<TechCard>), StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<TechCard>> GetAllAsync(CancellationToken cancellationToken) 
        => await _techCardService.GetAllAsync(cancellationToken);
    /// <summary>
    /// Создание тех.карты
    /// </summary>
    /// <param name="card"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<Guid> CreateAsync(TechCardCreateRequest card, CancellationToken cancellationToken)
    {
       var model = _mapper.Map<TechCardCreateRequest, TechCardCreateModel>(card);
       return await _techCardService.AddAsync(model, cancellationToken);
    }
    /// <summary>
    /// Удаление тех.карты
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _techCardService.DeleteByIdAsync(id, cancellationToken);
    }
}