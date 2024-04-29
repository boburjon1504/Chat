using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Web.Controllers;
public class AccountController(IAccountService accountService) : Controller
{
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async ValueTask<IActionResult> Register(User user)
    {
        try
        {
            var newUser = await accountService.RegisterAsync(user,HttpContext.RequestAborted);
        }catch (Exception ex)
        {
            ModelState.AddModelError("",ex.Message);
        }
        return View("Login", user);
    }
    public IActionResult Login()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("SimpleChat", "Home");
        }
        return View();
    }
    [HttpPost]
    public async ValueTask<IActionResult> Login(User user)
    {
       
            try
            {
                var token = await accountService.LoginAsync(new User { UserName = user.UserName, Password = user.Password });
                Response.Cookies.Append("token", token, new CookieOptions { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(1) });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",ex.Message);
                return View();
            }
            return RedirectToAction("SimpleChat", "Home");
    }
}
