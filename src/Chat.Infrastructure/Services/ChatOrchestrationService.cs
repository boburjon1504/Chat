using Chat.Application.Interfaces;
using Chat.Domain.Entities;

namespace Chat.Infrastructure.Services;
public class ChatOrchestrationService(
    IChatRoomService chatRoomService, 
    IMessageService messageService) : IChatOrchestrationService
{
    public async ValueTask<Message> SaveMessageToChatAsync(Guid senderId, Guid receiverId, string message,bool isDelivered,CancellationToken cancellationToken = default)
    {
        var chat = await chatRoomService.GetByUsersIdAsync(senderId, receiverId, true, cancellationToken);
        

        if(chat is null)
            chat = await chatRoomService.CreateAsync(senderId,receiverId,true, cancellationToken);

        if (!isDelivered && receiverId == chat.FirstUserId)
            chat.FirstUserUnReadMessageCount++;

        if (!isDelivered && receiverId == chat.SecondUserId)
            chat.SecondUserUnReadMessageCount++;

        var mes =  await messageService.CreateAsync(senderId, receiverId, chat.Id, message, isDelivered, true, cancellationToken);

        chat.LastMessageId = mes.Id;
        await chatRoomService.UpdateAsync(chat);

        return mes;
    }
}
