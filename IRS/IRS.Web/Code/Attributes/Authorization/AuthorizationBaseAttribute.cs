using IRS.Domain;
using IRS.Domain.Interfaces.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRS.Web.Code.Attributes.Authorization
{
    public class AuthorizationBaseAttribute : AuthorizeAttribute
    {
        private readonly IEnumerable<UserRole> _roles;

        public AuthorizationBaseAttribute(params UserRole[] roles)
        {
            _roles = roles ?? new UserRole[0];
        }

        private new IEnumerable<UserRole> Roles
        {
            get { return _roles; }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var urlHelper = new UrlHelper(filterContext.RequestContext);
            var request = filterContext.RequestContext.HttpContext.Request;

            var returnUrl = request.Url != null ? request.Url.PathAndQuery : string.Empty;
            filterContext.Result = new RedirectResult(urlHelper.Action("Forbidden", "Error", new {area="",returnurl=returnUrl}, request.Url.Scheme));
        }

   
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!base.AuthorizeCore(httpContext)) return false; // danied for unauthorized users

            var authenticatedUser = DependencyResolver.Current.GetService<IAuthUser>();

            var authorized = Roles.Any(role => role == authenticatedUser.Role);

            return authorized;
        }
    }
}