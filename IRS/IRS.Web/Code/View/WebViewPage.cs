using IRS.Domain.Interfaces.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRS.Web.Code.View
{
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        private readonly IConfigProvider _configProvider;

        public WebViewPage()
        {
            _configProvider = System.Web.Mvc.DependencyResolver.Current.GetService<IConfigProvider>();
        }

        public bool IsAuthenticated
        {
            get { return User.Identity.IsAuthenticated; }
        }

        public bool IsAdmin
        {
            get { return _configProvider.AuthUser.Role == Domain.UserRole.Admin; }
        }

        public bool IsUser
        {
            get { return _configProvider.AuthUser.Role == Domain.UserRole.User; }
        }

        public IConfigProvider ConfigProvider
        {
            get { return _configProvider; }
        }

        public IAuthUser AuthUser
        {
            get { return _configProvider.AuthUser; }
        }
    }

    public abstract class WebViewPage : System.Web.Mvc.WebViewPage<dynamic>
    {
    }
}