using Forpost.Business.Abstract.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.Contragents;
[ApiController]
[Route("api/v1/contragents")]
public class ContragentController: ControllerBase
{
    private readonly IContragentService _contragentService;

    public ContragentController(IContragentService contragentService)
    {
        _contragentService = contragentService;
    }

    /// <summary>
    /// Добавление контрагента
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(string name)
    {
        await _contragentService.Add(name);
        return Ok();
    }

    /// <summary>
    /// Получить всех контрагентов
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var contragents = await _contragentService.GetAll();
        return Ok(contragents);
    }

    /// <summary>
    /// Получить контрагента по id 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var contragent = await _contragentService.GetById(id);
        return Ok(contragent);
    }
}