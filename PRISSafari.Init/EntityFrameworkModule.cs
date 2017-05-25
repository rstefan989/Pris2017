using Autofac;
using System;
using System.Linq;

namespace PRISSafari.Init
{
    public class EntityFrameworkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            builder.RegisterType(typeof(Repositories.DataContext))
               .AsSelf().InstancePerLifetimeScope();

            builder.RegisterType(typeof(Repositories.Repositories.Common.UnitOfWork))
              .AsImplementedInterfaces().InstancePerLifetimeScope();
        }

        private bool ImplementsInterface(Type interfaceType, Type concreteType)
        {
            return
                concreteType.GetInterfaces().Any(
                    t =>
                        (interfaceType.IsGenericTypeDefinition && t.IsGenericType
                            ? t.GetGenericTypeDefinition()
                            : t) == interfaceType);
        }
    }
}
