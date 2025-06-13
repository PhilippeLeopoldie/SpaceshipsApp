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
    public async Task<IActionResult> MembersAsync()
    {
        var email = User.Identity?.Name ?? string.Empty;
        var user = await userService.GetUserByEmailAsync(email);

        var viewModel = new MembersVM()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
        };

        return View(viewModel);
    }

    [Authorize(Roles = "Administrator")]
    [HttpGet("admin")]
    public async Task<IActionResult> AdminsAsync()
    {
        var email = User.Identity?.Name ?? string.Empty;
        var user = await userService.GetUserByEmailAsync(email);
        var isAdmin = User.IsInRole("Administrator");

        var viewModel = new AdminsVM()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
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
        if (userDto.IsAdmin) return RedirectToAction(nameof(AdminsAsync).Replace("Async", ""));
        return RedirectToAction(nameof(MembersAsync).Replace("Async",""));
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
        if(user.IsAdmin) return RedirectToAction(nameof(AdminsAsync).Replace("Async", ""));
        return RedirectToAction(nameof(MembersAsync).Replace("Async", ""));
    }

    [HttpGet("logOut")]
    public async Task<IActionResult> LogOut()
    {
        await userService.SignOutAsync();
        return RedirectToAction(nameof(LoginAsync).Replace("Async", ""));
    }
}
