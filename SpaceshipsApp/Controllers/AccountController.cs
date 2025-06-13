using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spaceships.Application.Dtos;
using Spaceships.Application.Users;
using Spaceships.Web.Views.Account;

namespace Spaceships.Web.Controllers;

public class AccountController(IUserService userService) : Controller
{
    
    [Authorize]
    [HttpGet("members")]
    public IActionResult Members()
    {
        var firstName = User.FindFirst("FirstName")?.Value ?? string.Empty;
        var email = User.Identity?.Name ?? string.Empty;

        var viewModel = new MembersVM()
        {
            FirstName = firstName,
            Email = email,
        };

        return View(viewModel);
    }

    [Authorize(Roles = "Administrator")]
    [HttpGet("admin")]
    public IActionResult Admins()
    {
        var firstName = User.FindFirst("FirstName")?.Value ?? string.Empty;
        var email = User.Identity?.Name ?? string.Empty;
        var isAdmin = User.IsInRole("Administrator");

        var viewModel = new AdminsVM()
        {
            FirstName = firstName,
            Email = email,
            IsAdmin = isAdmin
        };
        return View(viewModel);
    }

    [HttpGet("register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterVM viewModel)
    {
        if (!ModelState.IsValid) return View();
        var userDto = new UserProfileDto(viewModel.Email, viewModel.FirstName, viewModel.LastName, viewModel.IsAdmin);
        var result = await userService.CreateUserAsync(userDto, viewModel.Password);
        if (!result.Succeded)
        {
            ModelState.AddModelError(string.Empty, result.ErrorMessage!);
            return View();
        }
        await userService.SignInAsync(viewModel.Email, viewModel.Password);
        if (userDto.IsAdmin) return RedirectToAction(nameof(Admins));
        return RedirectToAction(nameof(Members));
    }

 

    [HttpGet("login")]
    public IActionResult Login() => View();

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginVM viewModel)
    {
        if (!ModelState.IsValid) return View();

        var result = await userService.SignInAsync(viewModel.UserEmail, viewModel.Password);
        if (!result.Succeded)
        {
            ModelState.AddModelError(string.Empty, result.ErrorMessage!);
            return View();
        }
        var user = await userService.GetUserByEmailAsync(viewModel.UserEmail);
        if (user == null) 
        {
            ModelState.AddModelError(string.Empty, "Unexpected error: User data could not be loaded.");
            return View();
        }
        if(user.IsAdmin) return RedirectToAction(nameof(Admins));
        return RedirectToAction(nameof(Members));
    }

    [HttpGet("logOut")]
    public async Task<IActionResult> LogOut()
    {
        await userService.SignOutAsync();
        return RedirectToAction(nameof(LoginAsync).Replace("Async", ""));
    }
}
