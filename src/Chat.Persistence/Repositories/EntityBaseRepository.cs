using Chat.Domain.Common.Auditable;
using Chat.Domain.Entities;
using Chat.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Chat.Persistence.Repositories;
public abstract class EntityBaseRepository<TEntity>(ChatDbContext dbContext) where TEntity : Entity
{
    protected ChatDbContext DbContext => dbContext;
    protected async ValueTask<IList<TEntity>> GetAsync(CancellationToken cancellationToken) => await dbContext.Set<TEntity>().ToListAsync(cancellationToken);

    protected async ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<User>().FirstOrDefaultAsync(u => u.Id == id);
    }
    protected async ValueTask<TEntity> CreateAsync(TEntity user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<TEntity>().AddAsync(user);

        if (saveChanges)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        return user;
    }
    protected async ValueTask<TEntity> UpdateAsync(TEntity user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        dbContext.Set<TEntity>().Update(user);

        if (saveChanges)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        return user;
    }
    protected async ValueTask<TEntity> DeleteAsync(TEntity user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        dbContext.Set<TEntity>().Remove(user);

        if (saveChanges)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        return user;
    }
}
