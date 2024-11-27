using Forpost.Application.Contracts.Catalogs.Attributes;
using Forpost.Features.Catalogs.Products.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.Attributes;

[Route("api/v1/attributes")]
public sealed class AttributeController : ApiController
{
    /// <summary>
    /// Получить атрибут по ID 
    /// </summary>
    [HttpGet("{attributeId}")]
    [ProducesResponseType(typeof(AttributeModel), StatusCodes.Status200OK)] // Успешный запрос
    [ProducesResponseType(StatusCodes.Status404NotFound)] // Атрибут не найден
    public async Task<IActionResult> GetAttributeWithValueAsync(Guid attributeId, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetAllValueByAttributeIdQuery(attributeId), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получить все атрибуты 
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<AttributeModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAttributesAsync(CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new GetAllAttributesQuery(), cancellationToken));
    }

    /// <summary>
    /// Создать атрибут
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAttributeAsync([FromBody] AttributeRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateAttributeCommand(request.AttributeName, request.Values);
        var attributeId = await Sender.Send(command, cancellationToken);

        return CreatedAtRoute("", attributeId);
    }

    /// <summary>
    /// Добавить значения к атрибуту 
    /// </summary>
    [HttpPut("{attributeId}/values")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddValuesAttributeAsync(Guid attributeId,
        [FromBody] AttributeValuesRequest request,
        CancellationToken cancellationToken)
    {
        await Sender.Send(new AddAttributeValuesCommand(attributeId, request.AttributeValues), cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Изменить атрибут
    /// </summary>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAttributeAsync([FromBody] AttributeWithValuesRequest request,
        CancellationToken cancellationToken)
    {
        await Sender.Send(new UpdateAttributeCommand(request.Id, request.Name, request.Values), cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Удалить атрибут
    /// </summary>
    [HttpDelete("{attributeId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAttributeAsync(Guid attributeId, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteAttributeByIdCommand(attributeId), cancellationToken);
        return NoContent();
    }
}