using Chat.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Web.Controllers;
public class ChatController(IMessageService messageService) : Controller
{

    public IActionResult GetChatRoomMessages()
    {
        return View();
    }
}
