using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using Chat.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Services;
public class ChatRoomService(IChatRoomRepository repository) : IChatRoomService
{
    public IQueryable<ChatRoom> Get(bool asNoTracking = true)
    {
        return repository.Get(asNoTracking);
    }

    public async ValueTask<ChatRoom?> GetByUsersIdAsync(Guid firstUserId, Guid secondUserId, bool asNoTracking = true, CancellationToken cancellationToken = default) =>
        await Get(asNoTracking).FirstOrDefaultAsync(c => (c.FirstUserId == firstUserId && c.SecondUserId == secondUserId) ||
        (c.FirstUserId == secondUserId && c.SecondUserId == firstUserId));

    public async ValueTask<List<ChatRoom>> GetByUserIdAsync(Guid userId, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        return await repository.Get(asNoTracking)
            .Where(c => c.FirstUserId == userId || c.SecondUserId == userId)
            .Include(c => c.FirstUser)
            .Include(c => c.SecondUser)
            .ToListAsync();
    }

    public ValueTask<ChatRoom> CreateAsync(Guid firstUserId, Guid secondUserId, bool saveChanges, CancellationToken cancellationToken)
    {
        var chat = new ChatRoom
        {
            Id = Guid.NewGuid(),
            FirstUserId = firstUserId,
            SecondUserId = secondUserId,
        };
        return repository.CreateAsync(chat, saveChanges, cancellationToken);
    }

    public ValueTask<ChatRoom> UpdateAsync(ChatRoom chatRoom, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return repository.UpdateAsync(chatRoom, saveChanges, cancellationToken);
    }

    public ValueTask<ChatRoom> DeleteAsync(ChatRoom chatRoom, bool saveChanges, CancellationToken cancellationToken)
    {
        return repository.DeleteAsync(chatRoom, saveChanges, cancellationToken);
    }

}
