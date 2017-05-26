using Autofac;
using IRS.Infrastructure.UnitOfWork;
using IRS.Infrastructure.EF;
using IRS.Infrastructure.Repositories;
using IRS.Domain.Interfaces.Utilities;

namespace IRS.IoC.Modules
{
    public class InfrastructureModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<DataContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
