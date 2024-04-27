using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Persistence.DataContext;
public class ChatDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChatDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
