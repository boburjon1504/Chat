using Chat.Domain.Common.Auditable;

namespace Chat.Domain.Entities;
public class Message : Entity
{
    public Guid SenderId { get; set; }

    public Guid ReceiverId { get; set; }

    public Guid ChatId { get; set; }

    public string Body { get; set; } = default!;

    public DateTimeOffset SendAt { get; set; }

    public bool IsDelivered { get; set; }
}
