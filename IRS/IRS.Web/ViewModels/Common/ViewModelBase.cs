using IRS.Web.Code.Notification;
using IRS.Web.Code.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRS.Web.ViewModels.Common
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            Notifications = new NotificationCollection();
        }

        public INotificationCollection Notifications { get; set; }

        public Dictionary<string, string> Resources { get; set; }
    }
}