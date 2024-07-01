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

    [HttpPut]
    public async Task<string> AddSubProduct(string parentName, string daughterName, string unitOfMeasure, decimal quantity)
    {
        var result = await _subProductService.AddSubProduct(parentName, daughterName, unitOfMeasure, quantity);
        return result;
    }
}