using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Accounts;
using Forpost.Common.Utils;
using Forpost.Web.Contracts.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.Auth;

/// <summary>
/// Авторизация
/// </summary>
[ApiController]
[Route("api/v1/accounts")]
public sealed class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IIdentityProvider _identityProvider;
    private readonly IMapper _mapper;
    
    public AccountController(IAccountService accountService, IIdentityProvider identityProvider, IMapper mapper)
    {
        _accountService = accountService;
        _identityProvider = identityProvider;
        _mapper = mapper;
    }

    /// <summary>
    /// Регистрация сотрудника (регистрирует только админ?)
    /// </summary>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterAsync([FromQuery] RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<RegisterUserModel>(request);
        await _accountService.RegisterAsync(model, cancellationToken);
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
        var model = _mapper.Map<LoginUserModel>(request);

        var token = await _accountService.LoginAsync(model, cancellationToken);
        return token;
    }
}