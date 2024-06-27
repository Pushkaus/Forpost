using Forpost.Business.Abstract.Services;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Services;

public class AccountService: IAccountService
{
    private readonly IAccountRepository _accountRepository;
    
    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    public async Task<IActionResult> LoginAsync(string firstName, string lastName, string password)
    {
       var result = await _accountRepository.LoginAsync(firstName, lastName, password);
       return result;

    }

    public async Task<string> RegisterAsync(string firstName, string lastName, string? patronymic, string post, string role, string? email,
        string phoneNumber, string password, Guid userId)
    {
        var result = await _accountRepository.RegisterAsync(firstName, lastName, patronymic, post, role, email,
            phoneNumber, password, userId);
        return result;

    }
}