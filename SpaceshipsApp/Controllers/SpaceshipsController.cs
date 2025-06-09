using Microsoft.AspNetCore.Mvc;
using Spaceships.Application.Spaceships;

namespace Spaceships.Web.Controllers;

public class SpaceshipsController(ISpaceshipsService spaceshipService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
