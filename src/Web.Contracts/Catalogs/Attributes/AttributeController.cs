using Forpost.Features.Catalogs.Products.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.Attributes;

[Route("api/v1/attributes")]
public sealed class AttributeController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateAttributeAsync([FromBody] AttributeRequest request,
        CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new CreateAttributeCommand(request.AttributeName), cancellationToken));
    }

    [HttpPut("{attributeId}/value")]
    public async Task<IActionResult> AddValuesAttribute(Guid attributeId, [FromBody] AttributeValuesRequest request,
        CancellationToken cancellationToken)
    {
        await Sender.Send(new AddAttributeValuesCommand(attributeId, request.AttributeValues), cancellationToken);
        return NoContent();
    }

    [HttpGet("{attributeId}")]
    public async Task<IActionResult> GetAttributes(Guid attributeId, CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new GetAllValueByAttributeIdQuery(attributeId), cancellationToken));
    }
}