using Forpost.Application.Catalogs.Contractors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.Contractors;

/// <summary>
/// Справочник контрагентов
/// </summary>
[Route("api/v1/contragents")]
//[Authorize]
public sealed class ContractorController : ApiController
{
    /// <summary>
    /// Добавление контрагента
    /// </summary>
    /// <param name="name">Наименование контрагента</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync(string name, CancellationToken cancellationToken)
    {
        var id = await Mediator.Send(new AddContractorCommand(name), cancellationToken);
        return Ok(id);
    }

    /// <summary>
    /// Получить всех контрагентов
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ContractorResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var contractors = await Mediator.Send(new GetAllContractorsQuery(), cancellationToken);

        return Ok(Mapper.Map<IReadOnlyCollection<ContractorResponse>>(contractors));
    }

    /// <summary>
    /// Получить контрагента по id
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ContractorResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var contractor = await Mediator.Send(new GetContractorByIdQuery(id), cancellationToken);

        return Ok(Mapper.Map<ContractorResponse>(contractor));
    }
}