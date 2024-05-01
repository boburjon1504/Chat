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

        builder.HasOne(c => c.LastMessage).WithOne().HasForeignKey<ChatRoom>(c => c.LastMessageId);
    }
}
