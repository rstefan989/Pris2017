using Autofac;
using IRS.Domain.Interfaces.Configuration;
using IRS.Web.App_Start;
using IRS.Web.Code.Common;
using IRS.Web.Code.Utilities;
using log4net;
using Quartz;
using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace IRS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IContainer Container;
        public static IScheduler Scheduler;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Container = AutofacStartup.Init();
            AutoMapperStartUp.Init();
            
            Domain.Constants.DatabaseSchema = System.Configuration.ConfigurationManager.AppSettings["DatabaseSchema"];

            ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory(new LocalizedControllerActivator()));

            log4net.Config.XmlConfigurator.Configure();

            MvcHandler.DisableMvcResponseHeader = true; //this line is to hide mvc header
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;
            if (app != null && app.Context != null)
            {
                app.Context.Response.Headers.Remove("Server");
            }
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var x = HttpContext.Current.Items["x"];
            if (x != null)
            {
                var headers = HttpContext.Current.Response.Headers;
                headers.Remove("Set-Cookie");
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            ILog logger = LogManager.GetLogger("MvcLogger"); //ErrorAttribute Type - MethodBase.GetCurrentMethod().DeclaringType
            logger.Error(exc.Message, exc);

            //Redirect HTTP errors to HttpError page
            var root = (HttpRuntime.AppDomainAppVirtualPath.Length != 1) ? HttpRuntime.AppDomainAppVirtualPath: String.Empty;

#if (!DEBUG)
            {
                Response.Redirect(root + "/Error/Error");
                Server.ClearError();
            }
#endif
        }
    }
}
