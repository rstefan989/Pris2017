﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRS.Domain.Interfaces.Notification
{
    public interface INotification
    {
        string Title { get; set; }
        string Message { get; set; }
        NotificationType Type { get; set; }
    }
}
