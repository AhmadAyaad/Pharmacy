using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using ZPharmacy.API.EventHandler;

namespace ZPharmacy.API.Services
{
    public class ServicesStartup : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public ServicesStartup(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var eventsSubscriptionService = scope.ServiceProvider.GetService<IEventsSubscription>();
                eventsSubscriptionService.Subscribe();
            }

            StopAsync(cancellationToken);
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
