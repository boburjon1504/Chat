using Chat.Application.Interfaces;
using Chat.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Chat.Web.Controllers;
public class HomeController(IUserService userService) : Controller
{
    public IActionResult Index()
    {
        return View();
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
}
