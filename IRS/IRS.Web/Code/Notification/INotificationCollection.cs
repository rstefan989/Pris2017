using IRS.Domain;
using IRS.Domain.Interfaces.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRS.Web.Code.Notification
{
    public interface INotificationCollection : IRS.Domain.Interfaces.Notification.INotificationCollection
    {
        void AddErrors(System.Web.Mvc.ModelStateDictionary modelState);
    }

}