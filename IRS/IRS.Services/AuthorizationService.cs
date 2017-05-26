using IRS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRS.Domain.Entities;
using IRS.Domain;
using IRS.Domain.Interfaces.Utilities;
using IRS.Domain.Interfaces.Configuration;
using System.Security.Claims;

namespace IRS.Services
{
    public class AuthorizationService : ServiceBase, IAuthenticationService
    {
        IUserService _userService;
        IConfigProvider _configProvider;
        public AuthorizationService(IConfigProvider configProvider, 
                                    IUserService userService, 
                                    IIoCResolver ioCResolver) : base(ioCResolver)
        {
            _configProvider = configProvider;
            _userService = userService;
        }
        public ClaimsIdentity Authorize(string email, string password, out Domain.UserRole userRole)
        {
            var user = _userService.GetByEmail(email);

            if (user == null)
                throw new AccountNotExistsException();

            _userService.AuthenticateUser(user, password);

            userRole = (Domain.UserRole)user.RoleId;

            return  new ClaimsIdentity(new[] {
                    new Claim("UserId", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.RoleId.ToString())}, Constants.AppID);
        }

        public void LogOut()
        {
        }
    }
}
