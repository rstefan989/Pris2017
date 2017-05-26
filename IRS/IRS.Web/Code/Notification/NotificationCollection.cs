using IRS.Domain.Interfaces.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRS.Domain;
using System.Web.Mvc;
using IRS.Web.Code.Helpers;

namespace IRS.Web.Code.Notification
{
    public class NotificationCollection : List<INotification>, INotificationCollection
    {
        public INotification Add(string title, string message, NotificationType type)
        {
            var notification = new Notification() { Title = title, Message = message, Type = type };
            Add(notification);
            return notification;
        }

        public INotification AddError(string errorMessage)
        {
            return Add("Error", errorMessage, NotificationType.Error);
        }

        public INotification AddInformation(string informationMessage)
        {
            return Add("Information", informationMessage, NotificationType.Info);
        }

        public INotification AddWarning(string warningMessage)
        {
            return Add("Warning", warningMessage, NotificationType.Warning);
        }

        public void AddErrors(ModelStateDictionary modelState)
        {
            AddRange(modelState.AsErrorNotifications());
        }

    }
}
