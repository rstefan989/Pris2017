using Autofac;
using FluentValidation;
using System;

namespace PRISSafari.Init
{
    public class AutofacValidationFactory : ValidatorFactoryBase
    {
        private readonly IContainer _container;

        public AutofacValidationFactory(IContainer container)
        {
            _container = container;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            object instance;
            if (_container.TryResolve(validatorType, out instance))
            {
                return instance as IValidator;
            }
            return null;
        }
    }
}
