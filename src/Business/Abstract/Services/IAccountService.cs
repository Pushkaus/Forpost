using Forpost.Business.Models.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Abstract.Services;

public interface IAccountService : IBusinessService
{
    public Task<string> LoginAsync(LoginUserModel model, CancellationToken cancellationToken);
    public Task RegisterAsync(RegisterUserModel registerUserModel, CancellationToken cancellationToken);
}