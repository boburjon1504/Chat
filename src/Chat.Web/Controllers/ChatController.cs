using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Web.Controllers;
public class ChatController(IMessageService messageService) : Controller
{
    public IActionResult GetChatRoomMessages()
    {
        return View();
    }

    public IActionResult PrivateChat(string userId)
    {
        var user = GetRequestUserId();
        var secondUser = Guid.Parse(userId);
        List<Message>? messages = messageService.Get().Where(m => (m.SenderId == user && m.ReceiverId == secondUser) ||
        (m.SenderId == secondUser && m.ReceiverId == user)).ToList();
        return Ok(messages);
    }
    private Guid GetRequestUserId() => Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
}
