using log4net;
using System;
using System.Web;
using System.Web.Mvc;

namespace IRS.Web.Code.Attributes.Authorization
{
    public class ErrorAttribute : HandleErrorAttribute
    {
        string _logMessage;
        public ErrorAttribute(string logMessage = null)
        {
            _logMessage = logMessage;
        }
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            Exception ex = filterContext.Exception;

            ILog logger = LogManager.GetLogger(ex.TargetSite.DeclaringType); //ErrorAttribute Type - MethodBase.GetCurrentMethod().DeclaringType
            logger.Error((_logMessage != null) ? _logMessage : ex.Message, ex);

            var root = (HttpRuntime.AppDomainAppVirtualPath.Length != 1) ? HttpRuntime.AppDomainAppVirtualPath : String.Empty;
            filterContext.Result = new RedirectResult(root + "/Error/Error"); //redirect to Error page
        }
    }
}