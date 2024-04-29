using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Persistence.EntityConfigurations;
public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasOne<User>().WithMany().HasForeignKey(m=>m.SenderId);
        builder.HasOne<User>().WithOne().HasForeignKey<Message>(m => m.ReceiverId);
    }
}
