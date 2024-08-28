using Forpost.Application.Catalogs.TechCardItems;
using Forpost.Web.Contracts.Models.TechCardItems;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.Catalogs;
[Route("v1/api/tech-card-item")]
public sealed class TechCardItemController: ApiController
{
    /// <summary>
    /// Получение состава тех.карты по TechCardId
    /// </summary>
    /// <param name="techCardId">id тех.карты</param>
    /// <returns></returns>
    [HttpGet("{techCardId}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<Domain.Catalogs.TechCardItems.TechCardItem>), StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<Domain.Catalogs.TechCardItems.TechCardItem>> GetTechCardItems(Guid techCardId,
        CancellationToken cancellationToken)
    {
        return await Mediator.Send(new GetTechCardItemByIdQuery(techCardId), cancellationToken);
    }
    /// <summary>
    /// Добавления компонента в тех.карту
    /// </summary>
    /// <param name="techCardItem"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<Guid> CreateAsync(TechCardItemRequest model, CancellationToken cancellationToken)
    {
        return await Mediator.Send(new AddTechCardItemCommand(
            model.TechCardId,
            model.ProductId,
            model.Quantity), cancellationToken);
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
        //TODO;
    }
}