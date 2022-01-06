using Microsoft.Extensions.DependencyInjection;
using System;
using ZPharmacy.API.EventHandler.ISubscribers;
using ZPharmacy.Core.IServices;

namespace ZPharmacy.API.EventHandler
{
    public class EventsSubscription : IEventsSubscription
    {
        private readonly IServiceProvider _serviceProvider;
        private IProductService _productService;
        private readonly IEventSubscriber _eventSubscriber;

        public EventsSubscription(IServiceProvider serviceProvider, IEventSubscriber eventSubscriber, IProductService productService)
        {
            _serviceProvider = serviceProvider;
            _eventSubscriber = eventSubscriber;
            _productService = productService;
        }

        public IEventSubscriber EventSubscriber { get; }

        public void Subscribe()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                _productService = scope.ServiceProvider.GetService<IProductService>();


                _productService.AddEventListenerToProduct(_eventSubscriber.OnNewEvent);
            }
        }
    }
}
