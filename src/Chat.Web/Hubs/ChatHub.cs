using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Web.Hubs;

public class ChatHub(IUserService userService,IMessageService messageService) : Hub
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
        
        var receiverId = Guid.Parse(user);
        var receiver = await userService.GetByIdAsync(receiverId);
        if (receiver.IsOnline)
        {
            await SaveMessage(receiverId, message, true);
            await Clients.User(user).SendAsync("ReceiveMessage", user, message);
        }
        else
        {
            await SaveMessage(receiverId, message, false);
        }
    }
    private async Task SaveMessage(Guid receiverId,string message, bool isDelivered)
    {
        var newMessage = new Message
        {
            SenderId = GetRequestUser(),
            ReceiverId = receiverId,
            Body = message,
            SendAt = DateTimeOffset.Now,
            ChatId = receiverId ,
            IsDelivered = isDelivered
        };

        await messageService.CreateAsync(newMessage);
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
        var userId = Context.User.Claims.FirstOrDefault(c => c.Type.Equals("UserId")).Value;

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
