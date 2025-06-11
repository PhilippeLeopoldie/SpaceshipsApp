using Microsoft.AspNetCore.Mvc;
using Spaceships.Application.Spaceships;
using Spaceships.Domain.Entities;
using Spaceships.Web.Views.Spaceship;

namespace Spaceships.Web.Controllers;

public class SpaceshipsController(ISpaceshipsService spaceshipService) : Controller
{
    [HttpGet("")]
    public async Task<IActionResult> IndexAsync()
    {
        var model = await spaceshipService.GetAllAsync();
        
        var viewModel = new IndexVM()
        {
            SpaceshipVMs = [.. model
            .Select(s => new IndexVM.SpaceshipVM()
            {
                Id = s.Id,
                SpaceshipName = s.SpaceshipName,
                CompanyName = s.CompanyName,
                ImageUrl = s.ImageUrl,
            })]
        };

        return View(viewModel);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateVM viewModel)
    {
        if (!ModelState.IsValid)
            return View();

        SpaceShip spaceship = new()
        {
            SpaceshipName = viewModel.SpaceshipName,
            CompanyName = viewModel.CompanyName,
            Description = viewModel.Description,
            TransportType = viewModel.TransportType,
            ImageUrl = viewModel.ImageUrl,
        };

        await spaceshipService.AddAsync(spaceship);
        return RedirectToAction(nameof(IndexAsync).Replace("Async", string.Empty));
    }

    [HttpGet("details/{id}")]
    public async Task<IActionResult> DetailsAsync(int id)
    {
        var model = await spaceshipService.GetByIdAsync(id);

        var viewModel = new DetailsVM()
        {
            SpaceshipName = model!.SpaceshipName,
            CompanyName = model.CompanyName,
            Description = model.Description,
            TransportType = model.TransportType,
            ImageUrl = model.ImageUrl,
        };

        return View(viewModel);
    }
}
