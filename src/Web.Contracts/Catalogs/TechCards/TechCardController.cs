using Forpost.Domain.Catalogs.TechCards;
using Forpost.Features.Catalogs.TechCards;
using Forpost.Web.Contracts.Catalogs.TechCardSteps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.TechCards;

[Route("api/v1/techcard")]
public sealed class TechCardController : ApiController
{
    /// <summary>
    /// Получение состава тех.карты по Id 
    /// </summary>
    [HttpGet("composition/{techCardId}")]
    [ProducesResponseType(typeof(CompositionTechCardResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult?> GetCompositionTechCardAsync(Guid techCardId,
        CancellationToken cancellationToken)
    {
        var techCard = await Sender.Send(new GetCompositionTechCardQuery(techCardId), cancellationToken);

        var result = techCard != null
            ? Mapper.Map<CompositionTechCardResponse>(techCard)
            : new CompositionTechCardResponse
            {
                Id = techCardId,
                Steps = Array.Empty<StepSummaryResponse>(),
                Items = Array.Empty<ItemSummaryResponse>()
            };

        return Ok(result);
    }

    /// <summary>
    /// Получение тех.карты по Id
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(TechCard), StatusCodes.Status200OK)]
    public async Task<TechCard?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await Sender.Send(new GetTechCardByIdQuery(id), cancellationToken);

    /// <summary>
    /// Получение всех тех.карт
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<TechCardResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken,
        [FromQuery] int skip = 0, [FromQuery] int limit = 100,
        [FromQuery] string? filterExpression = null, [FromQuery] string?[]? filterValues = null)
    {
        var result = await Sender.Send(new GetAllTechCardsQuery(filterExpression, filterValues, skip, limit),
            cancellationToken);

        if (result.TechCards.Count == 0)
        {
            return NoContent();
        }

        return Ok(new
        {
            TechCards = Mapper.Map<IReadOnlyCollection<TechCardResponse>>(result.TechCards),
            TotalCount = result.TotalCount
        });
    }

    /// <summary>
    /// Создание тех.карты
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<Guid> CreateAsync(TechCardCreateRequest card, CancellationToken cancellationToken)
    {
        var techCardId = await Sender.Send(new AddTechCardCommand
        {
            Number = card.Number,
            Description = card.Description,
            ProductId = card.ProductId,
            CreatedById = card.CreatedById,
        }, cancellationToken);

        return techCardId;
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
        await Sender.Send(new DeleteTechCardCommand(id), cancellationToken);
        return NoContent();
    }
}