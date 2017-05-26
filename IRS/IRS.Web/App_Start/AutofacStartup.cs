using Autofac;
using Autofac.Integration.Mvc;
using IRS.Web.Code.Utilities;
using System.Reflection;
using System.Web.Mvc;

namespace IRS.Web.App_Start
{
    public class AutofacStartup
    {
        public static IContainer Init()
        {
            var builder = IRS.IoC.Initializer.Initialize(Assembly.GetExecutingAssembly());

            builder.RegisterModule<AutofacWebModule>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }
    }
}