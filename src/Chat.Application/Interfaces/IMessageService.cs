using Chat.Domain.Entities;

namespace Chat.Application.Interfaces;
public interface IMessageService
{
    IQueryable<Message> Get(bool asNoTracking = true);

    ValueTask<Message?> GetByIdAsync(Guid id, bool asNoTracking = true, CancellationToken cancellationToken = default);

    ValueTask<Message> CreateAsync(Message message, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Message> UpdateAsync(Message message, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<Message> DeleteAsync(Message message, bool saveChanges = true, CancellationToken cancellationToken = default);
}
