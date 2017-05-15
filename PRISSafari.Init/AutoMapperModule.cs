using Autofac;
using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace PRISSafari.Init
{
    public class AutoMapperModule : Autofac.Module
    {
        public Assembly WebProjectAssembly { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");

            builder.RegisterAssemblyTypes(WebProjectAssembly)
              .Where(t => typeof(Profile).IsAssignableFrom(t))
              .As<Profile>()
              .SingleInstance();
        }
    }
}
