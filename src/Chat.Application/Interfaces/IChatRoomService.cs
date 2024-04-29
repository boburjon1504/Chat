using Chat.Domain.Entities;

namespace Chat.Application.Interfaces;
public interface IChatRoomService
{
    IQueryable<ChatRoom> Get(bool asNoTracking = true);

    ValueTask<ChatRoom?> GetByIdAsync(Guid id, bool asNoTracking = true, CancellationToken cancellationToken = default);

    ValueTask<ChatRoom> CreateAsync(ChatRoom chatRoom, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<ChatRoom> UpdateAsync(ChatRoom chatRoom, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<ChatRoom> DeleteAsync(ChatRoom chatRoom, bool saveChanges = true, CancellationToken cancellationToken = default);
}
