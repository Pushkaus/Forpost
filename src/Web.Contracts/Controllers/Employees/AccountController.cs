using System.Security.Claims;
using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Accounts;
using Forpost.Business.Services;
using Forpost.Common.Utils;
using Forpost.Web.Contracts.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts;
/// <summary>
/// Контроллер для работы с сотрудниками
/// </summary>
[ApiController]
[Route("api/v1/accounts")]
sealed public class AccountController: ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IIdentityProvider _identityProvider;
    private readonly IMapper _mapper;

    /// <summary>
    /// Регистрация сервиса Accountservice
    /// </summary>
    /// <param name="accountService"></param>
    /// <param name="identityProvider"></param>
    /// <param name="mapper"></param>
    public AccountController(IAccountService accountService, IIdentityProvider identityProvider, IMapper mapper)
    {
        _accountService = accountService;
        _identityProvider = identityProvider;
        _mapper = mapper;
    }

    /// <summary>
    /// Регистрация сотрудника
    /// </summary>
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RegisterAsync([FromQuery] RegisterUserRequest request)
    {
        var model = _mapper.Map<RegisterUserModel>(request);
        await _accountService.RegisterAsync(model);
        return Ok();
    }
    /// <summary>
    /// Логин сотрудника
    /// </summary>
    [HttpPost("login")]
    public async Task<string> LoginAsync([FromQuery] LoginUserRequest request)
    {
        var model = _mapper.Map<LoginUserModel>(request);
        
        var token = await _accountService.LoginAsync(model);
        return token;
    }
    
}