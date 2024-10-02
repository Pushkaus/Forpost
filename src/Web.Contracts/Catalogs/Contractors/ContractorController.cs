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
    [HttpPost(Name = "CreateContractor")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromBody] ContractorRequest request,
        CancellationToken cancellationToken)
    {
        var id = await Sender.Send(new AddContractorCommand(request.Name), cancellationToken);
        return Created(HttpContext.Request.Path, id);
    }

    /// <summary>
    /// Получить всех контрагентов
    /// </summary>
    /// <returns>Список контрагентов</returns>
    [HttpGet(Name = "GetAllContractors")]
    //TODO: сделать ВЕЗДЕ модель пагинации, так как иначе сваггер и генератторы не поймут как десериализовывать ответ
    //ты тут написал что возврат коллекции идет, а по факту коллекция + число и это все в объекте json
    [ProducesResponseType(typeof(IReadOnlyCollection<ContractorResponse>), StatusCodes.Status200OK)]
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
    [HttpGet("{id:guid}", Name = "GetContractorById")]
    [ProducesResponseType(typeof(ContractorResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var contractor = await Sender.Send(new GetContractorByIdQuery(id), cancellationToken);

        return Ok(Mapper.Map<ContractorResponse>(contractor));
    }
}