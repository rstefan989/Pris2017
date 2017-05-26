using Autofac;
using IRS.Domain.Interfaces.Configuration;
using IRS.Domain.Interfaces.Utilities;
using IRS.Web.Code.Configuration;

namespace IRS.Web.Code.Utilities
{
    public class AutofacWebModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<IoCResolver>().As<IIoCResolver>().InstancePerLifetimeScope();
            builder.RegisterType<WebConfig>().As<IWebConfig>().SingleInstance();
            builder.RegisterType<ConfigProvider>().As<IConfigProvider>().InstancePerLifetimeScope();
            builder.RegisterType<AuthUser>().As<IAuthUser>().InstancePerLifetimeScope();
        }
    }
}