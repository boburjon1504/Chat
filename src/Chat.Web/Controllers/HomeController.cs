using Chat.Application.Interfaces;
using Chat.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Chat.Web.Controllers;
public class HomeController(IUserService userService, IChatRoomService chatRoomService) : Controller
{
    public async ValueTask<IActionResult> Index()
    {
        var userId = GetRequestUserId();
        var chats = await chatRoomService.GetByUserIdAsync(userId);
        chats.ForEach(c =>
        {
            if (c.FirstUserId == userId)
                c.FirstUser = null;
            else
                c.SecondUser = null;
        });
        return View(chats);
    }

    public async ValueTask<IActionResult> Privacy()
    {
        var users = await userService.GetAsync(HttpContext.RequestAborted);

        return View(users);
    }

    public IActionResult SimpleChat()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private Guid GetRequestUserId() => Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c=>c.Type == "UserId").Value);
}
