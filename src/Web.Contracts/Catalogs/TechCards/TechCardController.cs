using Forpost.Application.Catalogs.TechCards;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.TechCards;

[Route("v1/api/techcard")]
public sealed class TechCardController: ApiController
{
    /// <summary>
    /// Получение тех.карты по Id
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Domain.Catalogs.TechCards.TechCard), StatusCodes.Status200OK)]
    public async Task<Domain.Catalogs.TechCards.TechCard?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await Mediator.Send(new GetTechCardByIdQuery(id), cancellationToken);
    
    /// <summary>
    /// Получение всех тех.карт
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<Domain.Catalogs.TechCards.TechCard>), StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<Domain.Catalogs.TechCards.TechCard>> GetAllAsync(CancellationToken cancellationToken) 
        => await Mediator.Send(new GetAllTechCardsQuery(), cancellationToken);
    
    /// <summary>
    /// Создание тех.карты
    /// </summary>
    /// <param name="card"></param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<Guid> CreateAsync(TechCardCreateRequest card, CancellationToken cancellationToken)
    {
       var techCardId = await Mediator.Send(new AddTechCardCommand
       {
           Number = card.Number,
           Description = card.Description,
           ProductId = card.ProductId,
           CreatedById = card.CreatedById,
       }, cancellationToken);
       
       return techCardId;
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
        //TODO; 
    }
}