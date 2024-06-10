using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forpost.Store.Repositories.Abstract.Repositories
{
    public interface IAuthenticationRepository
    {
        public Task<IActionResult> Login(string userName, string userPassword, CancellationToken cancellationToken);
    }
}
