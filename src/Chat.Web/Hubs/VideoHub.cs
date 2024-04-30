using Microsoft.AspNetCore.SignalR;

namespace Chat.Web.Hubs;

public class VideoHub : Hub
{
    public async Task JoinMeetingAsync(string roomId, string userId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        await Clients.Group(roomId).SendAsync("UserConnected", userId);
    }
}
