using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.TechCardItems;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Models.TechCardItem;
using Forpost.Web.Contracts.Models.TechCardItems;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.TechCardItemController;
[ApiController]
[Route("v1/api/techcarditem")]
public sealed class TechCardItemController: ControllerBase
{
    private readonly ITechCardItemService _techCardItemService;
    private readonly IMapper _mapper;

    public TechCardItemController(ITechCardItemService techCardItemService, IMapper mapper)
    {
        _techCardItemService = techCardItemService;
        _mapper = mapper;
    }

    /// <summary>
    /// Получение состава тех.карты по TechCardId
    /// </summary>
    /// <param name="techCardId">id тех.карты</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{techCardId}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<TechCardItemEntity>), StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<TechCardItemsResponse>> GetTechCardItems(Guid techCardId,
        CancellationToken cancellationToken)
    {
        var techCardItems = await _techCardItemService.GetAllItemsByTechCardId(techCardId, cancellationToken);
        var result = _mapper.Map<IReadOnlyCollection<TechCardItemsResponse>>(techCardItems);
        return result;
    }
    /// <summary>
    /// Добавления компонента в тех.карту
    /// </summary>
    /// <param name="techCardItem"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<Guid> CreateAsync(TechCardItemRequest model, CancellationToken cancellationToken)
    {
        var techCardItem = _mapper.Map<TechCardItemCreateModel>(model);
        return await _techCardItemService.AddAsync(techCardItem, cancellationToken);
    } 

    /// <summary>
    /// Удаление компонента из тех.карты
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _techCardItemService.DeleteByIdAsync(id, cancellationToken);
    }
}