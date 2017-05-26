using IRS.Domain.Interfaces.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRS.Web.Code.Helpers
{
    public static class NotificationHelper
    {
        public static IEnumerable<INotification> AsErrorNotifications(this ModelStateDictionary modelState)
        {
            var errorNotifications = modelState.Values.SelectMany(x => x.Errors.Select(y => new Notification.Notification()
            {
                Message = y.ErrorMessage,
                Title = "Error",
                Type = IRS.Domain.NotificationType.Error
            }));

            return errorNotifications;
        }
    }
}