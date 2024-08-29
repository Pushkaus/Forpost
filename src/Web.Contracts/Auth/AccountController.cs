using Forpost.Application.Auth;
using Forpost.Application.Contracts.Catalogs.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Auth;

[Route("api/v1/accounts")]
public sealed class AccountController : ApiController

{
  

    /// <summary>
    /// Регистрация сотрудника (регистрирует только админ)
    /// </summary>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterAsync([FromQuery] RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var user = Mapper.Map<RegisterUserModel>(request);
        await Mediator.Send(new RegisterUserCommand(user), cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Логин сотрудника
    /// </summary>
    [HttpPost("login")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<string> LoginAsync([FromQuery] LoginUserRequest request, CancellationToken cancellationToken)
    {
        var token = await Mediator.Send(new LoginUserCommand(
            request.FirstName,
            request.LastName,
            request.Password), cancellationToken);
        
        return token;
    }
}