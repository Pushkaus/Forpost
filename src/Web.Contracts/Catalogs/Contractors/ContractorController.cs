using Forpost.Features.Catalogs.Contractors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.Contractors;

/// <summary>
/// Справочник контрагентов
/// </summary>
[Route("api/v1/contractors")]
//[Authorize]
public sealed class ContractorController : ApiController
{
    /// <summary>
    /// Добавление контрагента
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromBody] ContractorRequest request,
        CancellationToken cancellationToken)
    {
        var id = await Sender.Send(new AddContractorCommand(request.Name), cancellationToken);
        return Ok(id);
    }

    /// <summary>
    /// Получить всех контрагентов
    /// </summary>
    /// <returns>Список контрагентов</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ContractorResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken,
        [FromQuery] int skip = 0, [FromQuery] int limit = 100,
        [FromQuery] string? filterExpression = null, [FromQuery] string?[]? filterValues = null)
    {
        var result = await Sender.Send(new GetAllContractorsQuery(filterExpression, filterValues, skip, limit),
            cancellationToken);
        return Ok(new
        {
            Contractors = Mapper.Map<IReadOnlyCollection<ContractorResponse>>(result.Contractors),
            TotalCount = result.TotalCount
        });
    }

    /// <summary>
    /// Получить контрагента по id
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ContractorResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var contractor = await Sender.Send(new GetContractorByIdQuery(id), cancellationToken);

        return Ok(Mapper.Map<ContractorResponse>(contractor));
    }
}