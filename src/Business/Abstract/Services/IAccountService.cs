using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Abstract.Services;

public interface IAccountService : IBusinessService
{
    public Task<IActionResult> LoginAsync(string firstName, string lastName, string password);
    
    public Task<string> RegisterAsync(string firstName, string lastName, string? patronymic, string post, string role, string? email,
        string phoneNumber, string password, Guid userId);
    
}