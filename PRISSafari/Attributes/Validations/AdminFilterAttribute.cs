using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRISSafari.Attributes.Validations
{
    public class AdminFilterAttribute : ActionFilterAttribute
    {
        //public ICurrentUserProvider currentUserProvider { get; set; }

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if (filterContext == null)
        //        throw new ArgumentNullException("filterContext");

        //    switch (currentUserProvider.User.IsAdmin)
        //    {
        //        case true:
        //            return;
        //        case false:
        //            var request = filterContext.RequestContext.HttpContext.Request;
        //            var appPath = request.ApplicationPath;
        //            appPath = appPath.TrimEnd('/');
        //            filterContext.Result = new RedirectResult(appPath + "/Request/Forbidden");
        //            break;
        //    }
        //    return;
        //}
    }
}