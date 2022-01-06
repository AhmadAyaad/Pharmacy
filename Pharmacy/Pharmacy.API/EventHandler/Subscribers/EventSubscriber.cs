using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using ZPharmacy.API.EventHandler.ISubscribers;
using ZPharmacy.API.Hubs;
using ZPharmacy.Core.EventHandler;
using ZPharmacy.Identity.IServices;

namespace ZPharmacy.API.EventHandler.Subscribers
{
    public class EventSubscriber : IEventSubscriber
    {
        public const string NewChangeEvent = "NewChangeEvent";
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly IServiceProvider _serviceProvider;

        public EventSubscriber(IHubContext<NotificationHub> notificationHub, IServiceProvider serviceProvider)
        {
            _notificationHub = notificationHub;
            _serviceProvider = serviceProvider;
        }
        public void OnNewEvent(object sender, NotificationEventArgs args)
        {
            switch (args.Target)
            {
                case NotificationTarget.NotifyUser:
                    SendNotificationToUserAsync(sender, args as NotificationForUserEventArgs);
                    break;
                case NotificationTarget.NotifyUsers:
                    SendNotificationToUsersAsync(sender, args as NotificationForUsersEventArgs);
                    break;
                default:
                    break;
            }
        }

        public async Task SendNotificationToUserAsync(object sender, NotificationForUserEventArgs args)
        {
            PreParePayLoad(args);

            using (var scope = _serviceProvider.CreateScope())
            {
                var accountService = scope.ServiceProvider.GetRequiredService<IAccountService>();
                var userName = await accountService.GetUserNameAsync(args.UserId);
                await _notificationHub.Clients.User(userName).SendAsync(NewChangeEvent, args.EventName, args.Description, args.AdditionalParameter);
            }
        }

        public Task SendNotificationToUsersAsync(object sender, NotificationForUsersEventArgs args)
        {
            PreParePayLoad(args);
            return _notificationHub.Clients.Users(args.UserNames).SendAsync(NewChangeEvent, args.EventName, args.Description, args.AdditionalParameter);
        }

        //This method in case you need to prepare the payload
        //ex:- mapping payload to view model before sending to UI
        public virtual void PreParePayLoad(NotificationEventArgs args)
        {

        }
    }
}
