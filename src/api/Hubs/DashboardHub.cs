using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class DashboardHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}