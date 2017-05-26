using IRS.Domain.Interfaces.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRS.Domain;

namespace IRS.Web.Code.Notification
{
    public class Notification : INotification
    {
        public string Title
        {
            get; set;
        }

        public string Message
        {
            get; set;
        }

        public NotificationType Type
        {
            get; set;
        }
    }
}
