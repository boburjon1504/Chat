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

    public ValueTask<ChatRoom?> GetByIdAsync(Guid id, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        return repository.GetByIdAsync(id, asNoTracking, cancellationToken);
    }
    public async ValueTask<List<ChatRoom>> GetByUserIdAsync(Guid userId, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        return await repository.Get(asNoTracking)
            .Where(c => c.FirstUserId == userId || c.SecondUserId == userId)
            .Include(c => c.FirstUser)
            .Include(c => c.SecondUser)
            .ToListAsync();
    }

    public ValueTask<ChatRoom> CreateAsync(ChatRoom chatRoom, bool saveChanges, CancellationToken cancellationToken)
    {
        return repository.CreateAsync(chatRoom, saveChanges, cancellationToken);
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
