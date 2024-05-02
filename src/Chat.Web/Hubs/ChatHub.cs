using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Web.Hubs;

public class ChatHub(IUserService userService, IChatOrchestrationService chatOrchestrationService) : Hub
{
    public override async Task OnConnectedAsync()
    {
        await SetOnlineInformation(true);
    }


    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await SetOnlineInformation(false);
    }
    public async Task SendToUserMessage(string user, string message)
    {
        var senderId = GetRequestUser();
        var receiverId = Guid.Parse(user);

        var receiver = await userService.GetByIdAsync(receiverId);

        if (receiver.IsOnline)
        {
            var sender = await userService.GetByIdAsync(senderId);
            await chatOrchestrationService.SaveMessageToChatAsync(senderId, receiverId, message, true);
            await Clients.User(user).SendAsync("ReceiveMessage", sender.Id, sender.FirstName, sender.LastName, sender.IsOnline, message);
        }
        else
        {
            await chatOrchestrationService.SaveMessageToChatAsync(senderId, receiverId, message, false);
        }
    }
    private async Task SetOnlineInformation(bool isOnline)
    {
        Guid userId = GetRequestUser();

        var user = await userService.GetByIdAsync(userId);

        user.IsOnline = isOnline;

        await userService.UpdateAsync(user);

    }

    private Guid GetRequestUser()
    {
        var userId = Context.User?.Claims?.FirstOrDefault(c => c.Type.Equals("UserId"))?.Value;

        if (userId is null)
        {
            return Guid.Empty;
        }
        else
        {
            return Guid.Parse(userId);
        }
    }

}
