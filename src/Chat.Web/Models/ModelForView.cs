using Chat.Domain.Entities;

namespace Chat.Web.Models;

public class ModelForView
{
    public List<ChatRoom> Chats { get; set; } = new List<ChatRoom>();

    public User User { get; set; }
}
