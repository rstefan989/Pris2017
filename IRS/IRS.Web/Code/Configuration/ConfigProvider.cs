using IRS.Domain.Interfaces.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRS.Domain.Entities;
using System.Web.Mvc;
using IRS.Domain.Interfaces.Repositories;
using IRS.Domain.Interfaces.Services;

namespace IRS.Web.Code.Configuration
{
    public class ConfigProvider : IConfigProvider
    {
        HttpCookie _cookie;
        public ConfigProvider()
        {
            WebConfig = new WebConfig();
            AuthUser = new AuthUser();

            if (HttpContext.Current == null || HttpContext.Current.Handler == null) return;

            var cookies = HttpContext.Current.Request.Cookies;
            if (!cookies.AllKeys.Contains("AppSettingsCookie"))
            {
                _cookie = new HttpCookie("AppSettingsCookie") { Expires = DateTime.MaxValue }; //never expires
                _cookie.Values["SelectedLanguage"] = "en-US";
                HttpContext.Current.Response.SetCookie(_cookie);
            }
            else
                _cookie = cookies["AppSettingsCookie"];
        }

        public IAuthUser AuthUser
        {
            get; set;
        }

        public IWebConfig WebConfig
        {
            get; set;
        }

        public void SetLanguage(string selectedLanguage)
        {
            _cookie.Values["SelectedLanguage"] = selectedLanguage;
            HttpContext.Current.Response.SetCookie(_cookie);
        }

        public string SelectedLanguage
        {
            get
            {
                if (!_cookie.Values.AllKeys.Contains("SelectedLanguage"))
                    return WebConfig.DefaultCulture;
                else
                    return _cookie.Values["SelectedLanguage"];
            }
        }
    }
}