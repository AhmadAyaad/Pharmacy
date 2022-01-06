using System;
using System.Collections.Generic;
using ZPharmacy.Core.EventHandler;

namespace ZPharmacy.Core.Helpers
{
    public static class NotificationPublisherHelper
    {
        internal static void PublishForUser(this EventHandler<NotificationEventArgs> @event, object sender, string userId, string eventName, string description = null, object additionalParameter = null)
        {
            @event?.Invoke(sender, new NotificationForUserEventArgs
            {
                AdditionalParameter = additionalParameter,
                Target = NotificationTarget.NotifyUser,
                Description = description,
                EventName = eventName,
                UserId = userId
            });
        }
        internal static void PublishForUsers(this EventHandler<NotificationEventArgs> @event, object sender, List<string> userNames, string eventName, string description = null, object additionalParameter = null)
        {
            @event?.Invoke(sender, new NotificationForUsersEventArgs
            {
                AdditionalParameter = additionalParameter,
                Target = NotificationTarget.NotifyUsers,
                Description = description,
                EventName = eventName,
                UserNames = userNames
            });
        }
    }
}
