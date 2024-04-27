﻿using Chat.Domain.Entities;

namespace Chat.Persistence.Repositories.Interfaces;
public interface IUserRepository
{
    IQueryable<User> Get(bool asNoTracking = true);

    ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = true, CancellationToken cancellationToken = default);

    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
}
