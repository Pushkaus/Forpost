using Forpost.Business.Abstract.Services;
using Forpost.Web.Contracts.Models.Contragents;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.Contragents;

[ApiController]
[Route("api/v1/contragents")]
//[Authorize]
public sealed class ContractorController : ControllerBase
{
    private readonly IContragentService _contragentService;

    public ContractorController(IContragentService contragentService)
    {
        _contragentService = contragentService;
    }

    /// <summary>
    ///     Добавление контрагента
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync(string name, CancellationToken cancellationToken)
    {
        await _contragentService.AddAsync(name, cancellationToken);
        return Ok();
    }

    /// <summary>
    ///     Получить всех контрагентов
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ContractorResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var contragents = await _contragentService.GetAllAsync(cancellationToken);
        return Ok(contragents);
    }

    /// <summary>
    ///     Получить контрагента по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ContractorResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var contragent = await _contragentService.GetByIdAsync(id, cancellationToken);
        return Ok(contragent);
    }
}