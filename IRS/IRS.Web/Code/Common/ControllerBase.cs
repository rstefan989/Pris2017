using IRS.Domain.Interfaces.Configuration;
using IRS.Web.Code.Attributes.Authorization;
using IRS.Web.Code.Helpers;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.Mvc;
using YuSpin.Fw.Web.Serialization;

namespace IRS.Web.Code.Common
{
    [OutputCache(Duration = 0, NoStore = true)]
    public class ControllerBase : Controller
    {
        private readonly IConfigProvider _configProvider;
        public ControllerBase()
        {
            _configProvider = DependencyResolver.Current.GetService<IConfigProvider>();
        }
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonCamelCaseResult(data, contentType, contentEncoding, behavior);
        }

        internal JsonResult OkResult(string message)
        {
            var notifications = new Notification.NotificationCollection()
            {
                new Notification.Notification() { Message = message, Type = IRS.Domain.NotificationType.Info }
            };
            return Json(new { successful = true, notifications = notifications }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult CustomErrorResult(string message)
        {
            var notifications = new Notification.NotificationCollection()
            {
                new Notification.Notification() { Message = message, Type = IRS.Domain.NotificationType.Error }
            };
            return Json(new { successful = false, notifications = notifications }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult CustomWarningResult(string message)
        {
            var notifications = new Notification.NotificationCollection()
            {
                new Notification.Notification() { Message = message, Type = IRS.Domain.NotificationType.Warning }
            };
            return Json(new { successful = false, notifications = notifications }, JsonRequestBehavior.AllowGet);
        }

        internal JsonResult ErrorResult()
        {
            return Json(new { successful = false, notifications = ModelState.AsErrorNotifications() }, JsonRequestBehavior.AllowGet);
        }
    }
}