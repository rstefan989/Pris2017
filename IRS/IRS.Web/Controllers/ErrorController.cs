using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRS.Web.Controllers
{
    public class ErrorController : Code.Common.ControllerBase
    {
        [AllowAnonymous]
        public ActionResult Forbidden()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Error()
        {
            return View();
        }
    }
}