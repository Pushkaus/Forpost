using AutoMapper;
using Forpost.Business.Catalogs.TechCards;
using Forpost.Store.Entities.Catalog;
using Forpost.Web.Contracts.Models.TechCards;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.Catalog.TechCard;
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
    [ProducesResponseType(typeof(TechCardEntity), StatusCodes.Status200OK)]
    public async Task<TechCardEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await _techCardService.GetByIdAsync(id, cancellationToken);
    /// <summary>
    /// Получение всех тех.карт
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<TechCardEntity>), StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<TechCardEntity>> GetAllAsync(CancellationToken cancellationToken) 
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
       var model = _mapper.Map<TechCardCreateRequest, TechCardCreateCommand>(card);
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