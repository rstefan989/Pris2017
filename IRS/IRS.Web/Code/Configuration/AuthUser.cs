using IRS.Domain.Interfaces.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Web;
using IRS.Domain.Entities;
using System.Web.Mvc;
using IRS.Domain.Interfaces.Services;
using Microsoft.Owin;
using System.Resources;

namespace IRS.Web.Code.Configuration
{
    public class AuthUser: IAuthUser
    {
        
        public bool IsAuthenticated
        {
            get
            {
                return ClaimsPrincipal.Identity.IsAuthenticated;
            }
        }
        int _userId;
        public int UserId
        {
            get
            {
                if (_userId == 0)
                {
                    var claim = ClaimsPrincipal.Claims.SingleOrDefault(c => c.Type == "UserId");
                    _userId = int.Parse(claim.Value);
                }
                return _userId;
            }
            set { _userId = value; }
        }
        public Domain.UserRole Role
        {
            //TODO - optimization this part of code is needed
            get
            {
                var role = ClaimsPrincipal.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Role).Value;
                if (role == "1")
                    return Domain.UserRole.Admin;
                else 
                    return Domain.UserRole.User;
            }
        }
        public string FullName { get{ return ClaimsPrincipal.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name).Value; } }
        public string Email { get { return ClaimsPrincipal.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Email).Value; } }

        ClaimsPrincipal ClaimsPrincipal { get { return OwinContext.Authentication.User; } }
        IOwinContext OwinContext { get { return HttpContext.Current.Request.GetOwinContext(); } }

        public User AuthenticatedUser
        {
            get
            {
                var repo = DependencyResolver.Current.GetService<IUserService>();
                var user = repo.GetById(UserId);

                return user;
            }
        } 

        public bool ClaimsPrincipalExists()
        {
            return HttpContext.Current != null;
        }
    }
}