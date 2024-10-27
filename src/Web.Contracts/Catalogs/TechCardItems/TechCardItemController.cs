using Forpost.Domain.Catalogs.TechCardItems;
using Forpost.Features.Catalogs.TechCardItems;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.TechCardItems;
[Route("api/v1/tech-card-item")]
public sealed class TechCardItemController: ApiController
{
    /// <summary>
    /// Получение состава тех.карты по TechCardId
    /// </summary>
    [HttpGet("{techCardId}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<TechCardItem>), StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<TechCardItem>> GetTechCardItems(Guid techCardId,
        CancellationToken cancellationToken)
    {
        return await Sender.Send(new GetTechCardItemByIdQuery(techCardId), cancellationToken);
    }
    /// <summary>
    /// Добавления компонента в тех.карту
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<Guid> CreateAsync(TechCardItemRequest model, CancellationToken cancellationToken)
    {
        return await Sender.Send(new AddTechCardItemCommand(
            model.TechCardId,
            model.ProductId,
            model.Quantity), cancellationToken);
    } 

    /// <summary>
    /// Удаление компонента из тех.карты
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        //TODO;
    }
}