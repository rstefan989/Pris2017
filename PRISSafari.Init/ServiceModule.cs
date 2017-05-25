using Autofac;
using System;
using System.Linq;

namespace PRISSafari.Init
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            builder.RegisterAssemblyTypes(typeof(PRISSafari.Service.Services.UserService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();
        }
    }
}
