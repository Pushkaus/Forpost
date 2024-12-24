using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.TechCards;
using Forpost.Domain.Catalogs.TechCards;
using Forpost.Features.Catalogs.TechCards;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.TechCards;

[Route("api/v1/techcards")]
public sealed class TechCardController : ApiController
{
    /// <summary>
    /// Получение состава тех.карты по Id 
    /// </summary>
    [HttpGet("composition/{techCardId:guid}")]
    [ProducesResponseType(typeof(CompositionTechCardModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCompositionTechCardAsync(Guid techCardId,
        CancellationToken cancellationToken)
    {
        var composition = await Sender.Send(new GetCompositionTechCardQuery(techCardId), cancellationToken);
        return Ok(composition);
    }

    /// <summary>
    /// Получение тех.карты по Id
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(TechCard), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var techCard = await Sender.Send(new GetTechCardByIdQuery(id), cancellationToken);
        return Ok(techCard);
    }

    /// <summary>
    /// Получение всех тех.карт
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(EntityPagedResult<TechCardModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllAsync([FromQuery] TechCardFilter filter,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetAllTechCardsQuery(filter), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Создание тех.карты
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromBody] TechCardCreateRequest card, CancellationToken cancellationToken)
    {
        var techCardId = await Sender.Send(new AddTechCardCommand
        {
            Number = card.Number,
            Description = card.Description,
            ProductId = card.ProductId,
        }, cancellationToken);

        return CreatedAtRoute("", techCardId);
    }

    /// <summary>
    /// Обновление информации о тех.карте
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] TechCardCreateRequest card,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new UpdateTechCardCommand(id, card.Number, card.Description, card.ProductId),
            cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Удаление тех.карты
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new DeleteTechCardCommand(id), cancellationToken);
        return NoContent();
    }
}
