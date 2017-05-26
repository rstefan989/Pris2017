using IRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IRS.Domain.Interfaces.Services
{
    public interface IAuthenticationService: IServiceBase
    {
        ClaimsIdentity Authorize(string email, string password, out UserRole userRole);
        void LogOut();
    }
}
