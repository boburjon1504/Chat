using Chat.Domain.Entities;
using Chat.Persistence.DataContext;
using Chat.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chat.Persistence.Repositories;
public class UserRepository(ChatDbContext dbContext) : EntityBaseRepository<User>(dbContext), IUserRepository
{
    public IQueryable<User> Get(bool asNoTracking = true)
    {
        var initialQuery = DbContext.Users;

        if (asNoTracking)
            initialQuery.AsNoTracking();

        return initialQuery;
    }

    public ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, cancellationToken);
    }

    public new ValueTask<User> CreateAsync(User user, bool saveChanges, CancellationToken cancellationToken)
    {
        return base.CreateAsync(user, saveChanges, cancellationToken);
    }
    
    public new ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(user, saveChanges, cancellationToken);
    }


    public new ValueTask<User> DeleteAsync(User user, bool saveChanges, CancellationToken cancellationToken)
    {
        return base.DeleteAsync(user, saveChanges, cancellationToken);
    }
}
