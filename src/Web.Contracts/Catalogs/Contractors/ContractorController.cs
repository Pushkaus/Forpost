using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.Contractors;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.Catalogs.Contractors.ContractorRepresentatives;
using Forpost.Features.Catalogs.Contractors;
using Forpost.Features.Catalogs.Contractors.ContractorRepresentatives;
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
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromBody] ContractorRequest request,
        CancellationToken cancellationToken)
    {
        var id = await Sender.Send(new AddContractorCommand(
            request.Name,
            request.INN,
            request.Country,
            request.City,
            request.Description,
            request.DiscountLevel,
            request.LogisticInfo,
            request.ContractorType), cancellationToken);
        return CreatedAtRoute("", id);
    }

    /// <summary>
    /// Получить всех контрагентов
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(EntityPagedResult<ContractorModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllAsync([FromQuery] ContractorFilter filter,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetAllContractorsQuery(filter),
            cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получить контрагента по id
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ContractorModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var contractor = await Sender.Send(new GetContractorByIdQuery(id), cancellationToken);
        if (contractor == null)
            return NotFound();

        return Ok(contractor);
    }

    /// <summary>
    /// Обновление контрагента
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ContractorRequest request,
        CancellationToken cancellationToken)
    {
        await Sender.Send(
            new UpdateContractorCommand(id, request.Name, request.INN, request.Country, request.City,
                request.Description, request.DiscountLevel, request.LogisticInfo,
                ContractorType.FromValue(request.ContractorType)),
            cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Удаление контрагента
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteContractorCommand(id), cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Добавить представителя контрагента
    /// </summary>
    [HttpPost("contractor-representatives")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddContractorRepresantativeByContractorId(
        [FromBody] ContractorRepresentativeRequest request, CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(
            new AddContractorRepresentativeCommand(request.ContractorId, request.Name, request.Post,
                request.Description), cancellationToken));
    }
    /// <summary>
    /// Получить представителей контрагента
    /// </summary>
    [HttpGet("{contractorId:guid}/contractor-representatives")]
    [ProducesResponseType(typeof(ContractorRepresentativeRequest), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetContractorRepresentativeByContractorId(Guid contractorId,
        CancellationToken cancellationToken) =>
        Ok(await Sender.Send(new GetByContractorIdQuery(contractorId), cancellationToken));
    /// <summary>
    /// Удалить представителя контрагента
    /// </summary>
    [HttpDelete("contractor-representatives/{id:guid}")]
    public async Task<IActionResult> DeleteContractorRepresentativeById(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteByIdCommand(id), cancellationToken);
        return NoContent();
    }
    /// <summary>
    /// Изменить представителя контрагента
    /// </summary>
    [HttpPut("contractor-representatives/{id:guid}")]
    public async Task<IActionResult> UpdateContractorRepresentativeById(Guid id,
        [FromBody] ContractorRepresentativeRequest request)
    {
        await Sender.Send(new UpdateContractorRepresentativeByIdCommand(id, request.ContractorId, request.Name,
            request.Post, request.Description));
        return NoContent();
    }
}