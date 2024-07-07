using System.Collections;
using System.Security.Claims;
using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.ProductOperations;
[ApiController]
[Route("api/v1/product-operation")]
public class ProductOperationController: ControllerBase
{
    private readonly IProductOperationService _productOperationService;

    public ProductOperationController(IProductOperationService productOperationService)
    {
        _productOperationService = productOperationService;
    }
}