using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
using Forpost.Store.Repositories;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forpost.Business.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }
        public Task<IActionResult> Login(string userName, string userPassword, CancellationToken cancellationToken)
        {
           var token = _authenticationRepository.Login(userName, userPassword, cancellationToken);
           return token;
        }
    }
}
