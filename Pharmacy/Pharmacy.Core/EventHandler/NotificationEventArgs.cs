using System;
using System.Collections.Generic;

namespace ZPharmacy.Core.EventHandler
{
    public class NotificationEventArgs : EventArgs
    {
        public NotificationTarget Target { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public object AdditionalParameter { get; set; }

    }
    public class NotificationForUserEventArgs : NotificationEventArgs
    {
        public string UserId { get; internal set; }
    }
    public class NotificationForUsersEventArgs : NotificationEventArgs
    {
        public List<string> UserNames { get; set; }
    }
    public enum NotificationTarget
    {
        NotifyUser = 0,
        NotifyUsers = 1
    }
}
