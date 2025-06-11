using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spaceships.Application.Users;

namespace Spaceships.Web.Controllers;

public class AccountController(IUserService user) : Controller
{
    [Authorize]
    //[HttpGet("")]
    [HttpGet("members")]
    public IActionResult Members()
    {
        return View();
    }

    [HttpGet("register")]
    public IActionResult Register()
    {
        return View();
    }
}
