using Chat.Domain.Common.Auditable;

namespace Chat.Domain.Entities;
public class ChatRoom : Entity
{
    public Guid FirstUserId { get; set; }

    public Guid SecondUserId { get; set; }

    public virtual User FirstUser { get; set; }

    public virtual User SecondUser { get; set; }
}
