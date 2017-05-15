using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation;
using System.Reflection;
using System.Web.Mvc;

namespace PRISSafari.Init
{
    public class DependencyResolverInitializer
    {
        public static ContainerBuilder Initialize(Assembly assembly)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(assembly).InjectActionInvoker();
            builder.RegisterModelBinders(assembly);
            builder.RegisterModelBinderProvider();
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterType<ExtensibleActionInvoker>().As<IActionInvoker>();
            builder.RegisterFilterProvider();
            builder.RegisterModule<EntityFrameworkModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule(new AutoMapperModule { WebProjectAssembly = assembly });

            builder.RegisterAssemblyTypes(assembly)
            .Where(t => t.Name.EndsWith("ModelManager")).AsSelf().InstancePerLifetimeScope();

            var validators = AssemblyScanner.FindValidatorsInAssembly(assembly);
            validators.ForEach((validator) =>
            {
                builder
                    .RegisterType(validator.ValidatorType)
                    .As(validator.InterfaceType)
                    .SingleInstance();
            });

            return builder;
        }
    }
}
