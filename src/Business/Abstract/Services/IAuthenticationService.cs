using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Abstract.Services
{
    public interface IAuthenticationService: IBusinessService
    {
        public Task<IActionResult> Login(string userName, string userPassword, CancellationToken cancellationToken);
    }
}
