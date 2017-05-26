using Autofac;
using Autofac.Integration.Mvc;
using IRS.IoC.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using log4net;

namespace IRS.IoC
{
    public class Initializer
    {
        public static ContainerBuilder Initialize(Assembly assembly)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(assembly).InjectActionInvoker().PropertiesAutowired();
            builder.RegisterModelBinders(assembly);
            builder.RegisterModelBinderProvider();
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterType<ExtensibleActionInvoker>().As<IActionInvoker>();
            builder.RegisterFilterProvider();

            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<LoggingModule>();

            return builder;
        }

        #region ServiceModule

        #endregion
    }
}
