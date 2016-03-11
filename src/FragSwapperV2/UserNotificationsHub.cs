using System.Threading;
using Microsoft.AspNet.SignalR;

namespace FragSwapperV2.Hubs
{
    public class UserNotificationsHub : Hub
    {
        public void HandleUserNotification(string receivedString)
        {
            Clients.All.handleUserNotification("Boom goes the dynamite:" + receivedString);
        }
    }
}