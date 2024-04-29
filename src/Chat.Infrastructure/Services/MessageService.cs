﻿using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using Chat.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Services;
public class MessageService(IMessageRepository repository) : IMessageService
{
    public IQueryable<Message> Get(bool asNoTracking = true)
    {
        return repository.Get(asNoTracking);
    }

    public ValueTask<Message?> GetByIdAsync(Guid id, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        return repository.GetByIdAsync(id, asNoTracking,cancellationToken);
    }
    public async ValueTask<List<Message>> GetByChatRoomIdAsync(Guid chatRoomId, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        return await Get(asNoTracking).Where(m => m.ChatId == chatRoomId).ToListAsync();
    }

    public ValueTask<Message> CreateAsync(Message message, bool saveChanges, CancellationToken cancellationToken)
    {
        return repository.CreateAsync(message, saveChanges, cancellationToken);
    }

    public ValueTask<Message> UpdateAsync(Message message, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return repository.UpdateAsync(message, saveChanges, cancellationToken);
    }


    public ValueTask<Message> DeleteAsync(Message message, bool saveChanges, CancellationToken cancellationToken)
    {
        return repository.DeleteAsync(message, saveChanges, cancellationToken);
    }

}
