using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Persistence.EntityConfigurations;
public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasOne<User>().WithMany().HasForeignKey(m => m.SenderId);
        builder.HasOne<User>().WithOne().HasForeignKey<Message>(m => m.ReceiverId);
        builder.HasData(
        new Message
        {
            SenderId = Guid.Parse("5dff9d04-9a72-4cb8-bc73-63ad04078d2d"),
            ReceiverId = Guid.Parse("d288a320-adb3-4018-b6ce-449a124775fd"),
            SendAt = DateTimeOffset.UtcNow,
            Id = Guid.NewGuid(),
            Body = "Salom",
            IsDelivered = true
        }
        , new Message
        {
            SenderId = Guid.Parse("d288a320-adb3-4018-b6ce-449a124775fd"),
            ReceiverId = Guid.Parse("5dff9d04-9a72-4cb8-bc73-63ad04078d2d"),
            SendAt = DateTimeOffset.Now,
            Id = Guid.NewGuid(),
            Body = "Ishlaring yaxshimi",
            IsDelivered = true
        }
        );
    }
}
