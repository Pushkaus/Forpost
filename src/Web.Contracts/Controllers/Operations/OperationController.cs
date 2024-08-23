using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Operations;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Web.Contracts.Models.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.Operations;
[ApiController]
[Route("api/v1/operations")]
public sealed class OperationController: ControllerBase
{
    private readonly IOperationService _operationService;
    private readonly IMapper _mapper;

    public OperationController(IOperationService operationService, IMapper mapper)
    {
        _operationService = operationService;
        _mapper = mapper;
    }
    /// <summary>
    /// Добавление операции
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<Guid> AddAsync([FromBody] OperationRequest model, CancellationToken cancellationToken)
    {
        var operation = _mapper.Map<OperationModel>(model);
        return await _operationService.AddAsync(operation, cancellationToken);
    }
    /// <summary>
    /// Получение всех операций
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(Operation), StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<Operation>> GetAllAsync(CancellationToken cancellationToken)
        => await _operationService.GetAllAsync(cancellationToken);
    /// <summary>
    /// Удаление операции
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken) 
        => await _operationService.DeleteByIdAsync(id, cancellationToken);
}