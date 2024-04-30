using Chat.Domain.Entities;

namespace Chat.Application.Interfaces;
public interface IChatRoomService
{
    IQueryable<ChatRoom> Get(bool asNoTracking = true);


    ValueTask<List<ChatRoom>> GetByUserIdAsync(Guid userId, bool asNoTracking = true, CancellationToken cancellationToken = default);
    ValueTask<ChatRoom?> GetByUsersIdAsync(Guid firstUserId,Guid secondUserId, bool asNoTracking = true, CancellationToken cancellationToken = default);

    ValueTask<ChatRoom> CreateAsync(Guid firstUserId, Guid secondUserId, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<ChatRoom> UpdateAsync(ChatRoom chatRoom, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<ChatRoom> DeleteAsync(ChatRoom chatRoom, bool saveChanges = true, CancellationToken cancellationToken = default);
}
