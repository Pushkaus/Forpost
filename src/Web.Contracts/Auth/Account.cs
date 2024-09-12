using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Forpost.Application.Contracts.Catalogs.Employees;
using Forpost.Features.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Auth;

[Route("api/v1/accounts")]
public sealed class Account : ApiController
{
    /// <summary>
    /// Регистрация сотрудника (регистрирует только админ)
    /// </summary>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var user = Mapper.Map<RegisterUserModel>(request);
        await Sender.Send(new RegisterUserCommand(user), cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Логин сотрудника
    /// </summary>
    [HttpPost("login")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<string> LoginAsync([Required][FromBody] LoginUserRequest request, CancellationToken cancellationToken)
    {
        ///TODO; Убрать JSON.Parse в клиенте
        var token = await Sender.Send(new LoginUserCommand(
            request.FirstName,
            request.LastName,
            request.Password), cancellationToken);
        
        return token;
    }
}