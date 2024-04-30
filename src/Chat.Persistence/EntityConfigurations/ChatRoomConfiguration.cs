using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Persistence.EntityConfigurations;
public class ChatRoomConfiguration : IEntityTypeConfiguration<ChatRoom>
{
    public void Configure(EntityTypeBuilder<ChatRoom> builder)
    {
        builder.HasMany<Message>().WithOne().HasForeignKey(m => m.ChatId);

        builder.HasOne(c => c.FirstUser).WithMany().HasForeignKey(c => c.FirstUserId);

        builder.HasOne(c => c.SecondUser).WithMany().HasForeignKey(c => c.SecondUserId);

        builder.HasData(new ChatRoom
        {
            Id = Guid.Parse("141a18b0-9f76-4494-bd76-5d92a63891e7"),
            FirstUserId = Guid.Parse("d288a320-adb3-4018-b6ce-449a124775fd"),
            SecondUserId = Guid.Parse("5dff9d04-9a72-4cb8-bc73-63ad04078d2d"),
        });
    }
}
