using Chat.Domain.Entities;
using Chat.Persistence.DataContext;
using Chat.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chat.Persistence.Repositories;
internal class ChatRoomRepository(ChatDbContext dbContext) : EntityBaseRepository<ChatRoom>(dbContext), IChatRoomRepository
{
    public IQueryable<ChatRoom> Get(bool asNoTracking = true)
    {
        var initialQuery = DbContext.ChatRooms;

        if (asNoTracking)
            initialQuery.AsNoTracking();

        return initialQuery;
    }

    public ValueTask<ChatRoom?> GetByIdAsync(Guid id, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, cancellationToken);
    }

    public new ValueTask<ChatRoom> CreateAsync(ChatRoom chatRoom, bool saveChanges, CancellationToken cancellationToken)
    {
        return base.CreateAsync(chatRoom, saveChanges, cancellationToken);
    }

    public new ValueTask<ChatRoom> UpdateAsync(ChatRoom chatRoom, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(chatRoom, saveChanges, cancellationToken);
    }

    public new ValueTask<ChatRoom> DeleteAsync(ChatRoom chatRoom, bool saveChanges, CancellationToken cancellationToken)
    {
        return base.DeleteAsync(chatRoom, saveChanges, cancellationToken);
    }
}
