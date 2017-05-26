using IRS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRS.Web.Controllers
{
    public class HomeController : Code.Common.ControllerBase
    {
        IRS.Domain.Interfaces.Configuration.IConfigProvider _configProvider;
        public HomeController(IUserService service, IRS.Domain.Interfaces.Configuration.IConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}