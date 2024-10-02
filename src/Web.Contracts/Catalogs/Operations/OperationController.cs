using Forpost.Domain.Catalogs.Operations;
using Forpost.Features.Catalogs.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.Operations;

[Route("api/v1/operations")]
public sealed class OperationController: ApiController
{
    /// <summary>
    /// Добавление операции
    /// </summary>
    [HttpPost(Name = "CreateOperation")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<Guid> AddAsync([FromBody] string operationName, CancellationToken cancellationToken)
    {
        return await Sender.Send(new AddOperationCommand(operationName), cancellationToken);
    }
    /// <summary>
    /// Получение всех операций
    /// </summary>
    [HttpGet(Name = "GetAllOperations")]
    [ProducesResponseType(typeof(IReadOnlyCollection<Operation>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IReadOnlyCollection<Operation>> GetAllAsync(CancellationToken cancellationToken)
    {
        var result =  await Sender.Send(new GetAllOperationsQuery(), cancellationToken);
        return result.Operations;
    }
}