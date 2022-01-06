using System.Threading.Tasks;
using ZPharmacy.Core.EventHandler;

namespace ZPharmacy.API.EventHandler.ISubscribers
{
    public interface IEventSubscriber
    {
        void OnNewEvent(object sender, NotificationEventArgs args);
        Task SendNotificationToUserAsync(object sender, NotificationForUserEventArgs args);
        Task SendNotificationToUsersAsync(object sender, NotificationForUsersEventArgs args);
    }
}
