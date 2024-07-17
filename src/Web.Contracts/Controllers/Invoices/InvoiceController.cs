using System.Net;
using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Invoices;
using Forpost.Store.Entities;
using Forpost.Store.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts;
[ApiController]
[Route("api/v1/invoices")]

public class InvoiceController: ControllerBase
{
    private readonly IInvoiceService _invoiceService;
    private readonly IMapper _mapper;
    public InvoiceController(IInvoiceService invoiceService, IMapper mapper)
    {
        _invoiceService = invoiceService;
        _mapper = mapper;
    }
    /// <summary>
    /// Получить счет по его номеру
    /// </summary>
    [HttpGet("{number}")]
    public async Task<IActionResult> GetByNumber(string number)
    {
        var invoice = await _invoiceService.GetByNumber(number);
        return Ok(invoice);
    }

    /// <summary>
    /// Получить все счета
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var invoices = await _invoiceService.GetAll();
        return Ok(invoices);
    }

    /// <summary>
    /// Создать счет
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromQuery] InvoiceCreateRequest request)
    {
        var model = _mapper.Map<InvoiceCreateModel>(request);
        await _invoiceService.Create(model);
        return Ok();
    }

    /// <summary>
    /// Обновление счета
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromQuery] InvoiceUpdateRequest request)
    {
        var model = _mapper.Map<InvoiceUpdateModel>(request);
        await _invoiceService.Update(model);
        return Ok();
    }

    /// <summary>
    /// Удалить счет по его id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _invoiceService.DeleteById(id);
        return Ok();
    }
    
    
}