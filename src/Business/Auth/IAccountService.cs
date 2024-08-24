using Forpost.Business.Auth.Commands;

namespace Forpost.Business.Auth;

public interface IAccountService : IBusinessService
{
    public Task<string> LoginAsync(LoginUserCommand model, CancellationToken cancellationToken);
    public Task RegisterAsync(RegisterUserCommand registerUserCommand, CancellationToken cancellationToken);
}