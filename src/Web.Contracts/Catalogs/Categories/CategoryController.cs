using Forpost.Application.Contracts.Catalogs.Categories;
using Forpost.Features.Catalogs.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Catalogs.Categories;

[Route("api/v1/categories")]
public sealed class CategoryController : ApiController
{
    /// <summary>
    /// Создание категории
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> AddAsync([FromBody] CategoryRequest request, CancellationToken cancellationToken)
    {
        var result =
            await Sender.Send(new AddCategoryCommand(request.Name, request.ParentCategoryId, request.Description),
                cancellationToken);
        return Ok(result);
    }
    /// <summary>
    /// Получить все категории
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<CategoryWithChildrenModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync([FromQuery] CategoryFilter filter,
        CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new GetAllCategoryQuery(filter), cancellationToken));
    }
}