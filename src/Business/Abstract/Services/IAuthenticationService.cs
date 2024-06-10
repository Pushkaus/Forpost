using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forpost.Business.Abstract.Services
{
    public interface IAuthenticationService: IBusinessService
    {
        public Task<IActionResult> Login(string userName, string userPassword, CancellationToken cancellationToken);
    }
}
