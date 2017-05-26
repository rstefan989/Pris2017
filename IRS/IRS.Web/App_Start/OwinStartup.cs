using IRS.Domain;
using IRS.Domain.Interfaces.Configuration;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.Owin.Infrastructure;
using YuSpin.Fw.Web.Owin;

[assembly: OwinStartup(typeof(IRS.Web.App_Start.OwinStartup))]
namespace IRS.Web.App_Start
{
    public class OwinStartup
    {
        public OwinStartup() {}

        public void Configuration(IAppBuilder app)
        {
            var webConfig = DependencyResolver.Current.GetService<IWebConfig>();

            CustomAuthenticationMiddleware.AppID = Constants.AppID;
            app.Use(typeof(CustomAuthenticationMiddleware));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = Constants.AppID,
                LoginPath = new PathString("/account/login"),
                SlidingExpiration=true,  
                Provider = new CookieAuthenticationProvider() // --> prevents wrong http code to be returned for Ajax calls https://brockallen.com/2013/10/27/using-cookie-authentication-middleware-with-web-api-and-401-response-codes/
                {
                    OnApplyRedirect = ctx =>
                    {
                        if (!IsAjaxRequest(ctx.Request))
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }
                    },
                    OnValidateIdentity = CustomValidateIdentity
                }
            });

            AntiForgeryConfig.UniqueClaimTypeIdentifier = "UserId";
        }

        private static bool IsAjaxRequest(IOwinRequest request)
        {
            IReadableStringCollection query = request.Query;
            if ((query != null) && (query["X-Requested-With"] == "XMLHttpRequest"))
            {
                return true;
            }
            IHeaderDictionary headers = request.Headers;
            return ((headers != null) && (headers["X-Requested-With"] == "XMLHttpRequest"));
        }

        private static Task CustomValidateIdentity(CookieValidateIdentityContext context)
        {
            var authCookieExpires = context.Properties.ExpiresUtc.Value.ToLocalTime();
            HttpContext.Current.Items["AuthCookieExpirationTime"] = authCookieExpires;

            return Task.FromResult(0);
        }
    }
}