using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Forpost.Web.Contracts.OrderBlock;

[Route("api/[controller]")]
[ApiController]
public sealed class OrderBlockController : Controller
{
    [HttpGet]
    public static IEnumerable<OrderBlockResponse> Get()
    {
        return Get();
    }
   
}
