using System.Collections;
using Forpost.Business.Abstract.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.SubProduct;
[ApiController]
[Route("api/v1/sub-product")]
public class SubProductController: ControllerBase
{
    private readonly ISubProductService _subProductService;

    public SubProductController(ISubProductService subProductService)
    {
        _subProductService = subProductService;
    }

    /// <summary>
    /// Добавление субпродукта
    /// </summary>
    /// <param name="parentName"></param>
    /// <param name="daughterName"></param>
    /// <param name="unitOfMeasure"></param>
    /// <param name="quantity"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<string> AddSubProduct(string parentName, string daughterName, string unitOfMeasure, decimal quantity)
    {
        var result = await _subProductService.AddSubProduct(parentName, daughterName, unitOfMeasure, quantity);
        return result;
    }
    /// <summary>
    /// Получить субпродукты 
    /// </summary>
    /// <param name="parentName"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IEnumerable> GetSubProductsByParent(string parentName)
    {
        var result = await _subProductService.GetSubProductsByParent(parentName);
        return result;
    }
}