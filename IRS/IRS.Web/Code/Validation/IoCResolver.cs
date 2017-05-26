using Autofac;
using IRS.Domain.Interfaces.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRS.Web.Code.Utilities
{
    
    public class IoCResolver : IIoCResolver
    {
        private readonly IComponentContext _componentContext;
        public IoCResolver(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }
        public T Resolve<T>()
        {
            var obj = _componentContext.Resolve<T>();
            return obj;
        }

        public object Resolve(Type type)
        {
            var obj = _componentContext.Resolve(type);
            return obj;
        }
    }
}