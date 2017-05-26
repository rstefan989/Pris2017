using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuSpin.Fw.Web.Owin
{
    public class CustomAuthenticationMiddleware : OwinMiddleware
    {
        public static string AppID = "AuthCookie";
        string AuthenticationCookie { get { return CookieAuthenticationDefaults.CookiePrefix + AppID; } }

        public CustomAuthenticationMiddleware(OwinMiddleware next) :
            base(next)
        { }

        public override async Task Invoke(IOwinContext context)
        {
            var response = context.Response;
            response.OnSendingHeaders(state =>
            {
                var resp = (OwinResponse)state;

                if (resp.Environment.ContainsKey("DoNotRefreshAuthCookie"))
                {
                    resp.Cookies.Delete(AuthenticationCookie);
                }
            }, response);

            await Next.Invoke(context);
        }
    }
}
