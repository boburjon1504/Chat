using Chat.Domain.Entities;

namespace Chat.Application.Interfaces;
public interface IChatOrchestrationService
{
    ValueTask<Message> SaveMessageToChatAsync(Guid senderId, Guid receiverId, string message,bool isDelivered, CancellationToken cancellationToken = default);
}
