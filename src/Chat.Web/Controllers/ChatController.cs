using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Web.Controllers;
public class ChatController(IMessageService messageService, IChatRoomService chatRoomService) : Controller
{
    public IActionResult GetChatRoomMessages()
    {
        return View();
    }
    [HttpGet]
    public async ValueTask<IActionResult> PrivateChat(string userId)
    {
        var user = GetRequestUserId();
        var secondUser = Guid.Parse(userId);
        var chat = await chatRoomService.GetByUsersIdAsync(user, secondUser);
        if(chat is not null && chat.FirstUserId == user)
            chat.FirstUserUnReadMessageCount = 0;

        if (chat is not null && chat.SecondUserId == user)
            chat.SecondUserUnReadMessageCount = 0;

       if(chat is not null)
            await chatRoomService.UpdateAsync(chat);

        List<Message>? messages = messageService.Get().Where(m => (m.SenderId == user && m.ReceiverId == secondUser) ||
        (m.SenderId == secondUser && m.ReceiverId == user)).ToList();
        return Ok(messages);
    }
    public IActionResult Index(string roomId)
    {
        return Redirect($"/{Guid.NewGuid()}");
    }
    [HttpGet("/{roomId}")]
    public IActionResult Room(string roomId)
    {
        ViewBag.roomId = roomId;
        return View();
    }

    private Guid GetRequestUserId() => Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
}
