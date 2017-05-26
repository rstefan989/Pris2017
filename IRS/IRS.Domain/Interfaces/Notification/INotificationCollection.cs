using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRS.Domain.Interfaces.Notification
{
    public interface INotificationCollection: ICollection<INotification>
    {
        INotification Add(string title, string text, NotificationType type);
        INotification AddError(string errorMessage);
        INotification AddWarning(string warningMessage);
        INotification AddInformation(string informationMessage);
    }
}
