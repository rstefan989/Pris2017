using IRS.Domain.Interfaces.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IRS.Web.Code.Common
{
    public class LocalizedControllerActivator : IControllerActivator
    {
        private IConfigProvider _configProvider;
        public LocalizedControllerActivator()
        {
        }
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            _configProvider = DependencyResolver.Current.GetService<IConfigProvider>();

            string lang = _configProvider.SelectedLanguage;

            if (lang != _configProvider.WebConfig.DefaultCulture)
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture =
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
                }
                catch (Exception)
                {
                    throw new NotSupportedException(String.Format("ERROR: Invalid language code '{0}'.", lang));
                }
            }

            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }
}