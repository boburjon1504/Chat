using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using Chat.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Chat.Web.Controllers;
public class HomeController(IUserService userService, IChatRoomService chatRoomService) : Controller
{
    public async ValueTask<IActionResult> Index()
    {
        var userId = GetRequestUserId();

        if (userId == Guid.Empty)
            return RedirectToAction("Login", "Account");

        var chats = await chatRoomService.GetByUserIdAsync(userId);
        var modelView = new ModelForView
        {
            User = await userService.GetByIdAsync(userId, HttpContext.RequestAborted),
            Chats = chats
        };

        return View(modelView);
    }

    public async ValueTask<IActionResult> Privacy()
    {
        var users = await userService.GetAsync(HttpContext.RequestAborted);

        return View(users);
    }

    [HttpGet]
    public IActionResult Get(string term)
    {
        if (term is null)
            return Ok(new List<User>());
        var userId = GetRequestUserId();
        var users = (userService.Get()
            .Where(u => u.Id != userId)
            .Where(u =>
        u.FirstName.ToLower().Contains(term.ToLower()) ||
        u.LastName.ToLower().Contains(term.ToLower()) ||
        u.UserName.ToLower().Contains(term.ToLower())
        )).ToList();

        return Json(users);
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

    private Guid GetRequestUserId()
    {
        var user = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");

        return user is null ? Guid.Empty : Guid.Parse(user.Value);
    }

}
