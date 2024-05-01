using Chat.Domain.Common.Auditable;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.Domain.Entities;
public class ChatRoom : Entity
{
    public Guid FirstUserId { get; set; }

    public Guid SecondUserId { get; set; }

    public virtual User FirstUser { get; set; }

    public virtual User SecondUser { get; set; }

    public int FirstUserUnReadMessageCount { get; set; }
    public int SecondUserUnReadMessageCount { get; set; }

    public Guid? LastMessageId { get; set; }

    public Message LastMessage { get; set; }
}
