using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Owin;
using System.Web;

namespace YuSpin.Fw.Web.Owin.Attributes
{
    public class DoNotResetAuthCookieAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.GetOwinContext().Environment.Add("DoNotRefreshAuthCookie", true);
        }
    }
}
