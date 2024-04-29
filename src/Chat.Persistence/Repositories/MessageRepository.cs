using Chat.Domain.Entities;
using Chat.Persistence.DataContext;
using Chat.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chat.Persistence.Repositories;
public class MessageRepository(ChatDbContext dbContext) : EntityBaseRepository<Message>(dbContext), IMessageRepository
{
    public IQueryable<Message> Get(bool asNoTracking = true)
    {
        var initialQuery = DbContext.Messages;

        if (asNoTracking)
            initialQuery.AsNoTracking();

        return initialQuery;
    }

    public ValueTask<Message?> GetByIdAsync(Guid id, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, cancellationToken);
    }

    public new ValueTask<Message> CreateAsync(Message message, bool saveChanges, CancellationToken cancellationToken)
    {
        return base.CreateAsync(message, saveChanges, cancellationToken);
    }

    public new ValueTask<Message> UpdateAsync(Message message, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(message, saveChanges, cancellationToken);
    }

    public new ValueTask<Message> DeleteAsync(Message message, bool saveChanges, CancellationToken cancellationToken)
    {
        return base.DeleteAsync(message, saveChanges, cancellationToken);
    }
}
