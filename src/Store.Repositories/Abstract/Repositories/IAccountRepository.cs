using Microsoft.AspNetCore.Mvc;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IAccountRepository
{
    public Task<IActionResult> LoginAsync(string firstName, string lastName, string password);
    
    public Task<string> RegisterAsync(string firstName, string lastName, string? patronymic, string post, string role, string? email,
        string phoneNumber, string password, Guid userId);
}