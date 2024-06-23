using Forpost.Business.Abstract.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Account;
/// <summary>
/// Контроллер для работы с сотрудниками
/// </summary>
[ApiController]
[Route("api/v1/account")]
public class AccountController: ControllerBase
{
    private readonly IAccountService _accountService;
    /// <summary>
    /// Регистрация сервиса Accountservice
    /// </summary>
    /// <param name="accountService"></param>
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    /// <summary>
    /// Регистрация сотрудника
    /// </summary>
    [HttpPut("register")]
    public async Task<string> RegisterAsync(string firstName, string lastName, string? patronymic,
        string post, string role, string? email, string phoneNumber, string password)
    {
        var result = await _accountService.RegisterAsync(
            firstName, 
            lastName,
            patronymic,
            post,
            role,
            email,
            phoneNumber,
            password);
        return result;
    }
/// <summary>
/// Логин сотрудника
/// </summary>
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(string firstName, string lastName, string password)
    {
        var result = await _accountService.LoginAsync(firstName, lastName, password);
        
        return result;
    }
    
}