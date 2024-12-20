using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.TechCards.TechCardItems;
using Forpost.Domain.Catalogs.TechCards.TechCardItems;
using Forpost.Features.Catalogs.TechCards.TechCardItems;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.TechCardItems;

[Route("api/v1/tech-card-item")]
public sealed class TechCardItemController : ApiController
{
    /// <summary>
    /// Получение состава тех.карты по TechCardId
    /// </summary>
    [HttpGet("{techCardId}")]
    [ProducesResponseType(typeof(EntityPagedResult<TechCardItemModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTechCardItems(Guid techCardId,
        [FromQuery] TechCardItemFilter filter,
        CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new GetTechCardItemByIdQuery(techCardId, filter), cancellationToken));
    }

    /// <summary>
    /// Добавление компонента в техкарту
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<Guid> CreateAsync([FromBody] TechCardItemRequest model, CancellationToken cancellationToken)
    {
        return await Sender.Send(new AddTechCardItemCommand(
            model.TechCardId,
            model.ProductId,
            model.Quantity), cancellationToken);
    }

    /// <summary>
    /// Обновление компонента в техкарте
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] TechCardItemRequest model,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new UpdateTechCardItemCommand(
            id,
            model.TechCardId,
            model.ProductId,
            model.Quantity), cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Удаление компонента из техкарты
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteTechCardItemCommand(id), cancellationToken);
        return NoContent();
    }
}