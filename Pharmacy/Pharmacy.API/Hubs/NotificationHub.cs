using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ZPharmacy.API.Hubs
{
    [Authorize]
    public class NotificationHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            var role = Context?.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            await Groups.AddToGroupAsync(Context.ConnectionId, role);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var role = Context?.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, role);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
