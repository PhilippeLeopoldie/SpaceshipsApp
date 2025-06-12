using Microsoft.AspNetCore.Mvc;
using Moq;
using Spaceships.Application.Spaceships;
using Spaceships.Domain.Entities;
using Spaceships.Domain.Entities.Enums;
using Spaceships.Web.Controllers;
using Spaceships.Web.Views.Spaceship;

namespace Spaceships.Web.Tests;

public class SpaceshipsControllerTests
{
    [Fact]
    public async Task Details_WithId_ReturnsViewResult()
    {
        // Arrange
        var spaceshipService = new Mock<ISpaceshipsService>();
        var spaceshipController = new SpaceshipsController(spaceshipService.Object);
        var spaceship = GetMockSpaceship();

        spaceshipService
            .Setup(service => service.GetByIdAsync(1))
            .ReturnsAsync(spaceship);

        // Act
        var result = await spaceshipController.DetailsAsync(1);

        // Assert
        Assert.IsType<ViewResult>(result);
        spaceshipService.Verify(s => s.GetByIdAsync(1), Times.Once);
    }

    [Theory]
    [InlineData("Dragon Cargo", "SpaceX", "SpaceX's uncrewed spacecraft used to deliver supplies to the ISS.", "/Images/dragon-cargo.jpg", TransportType.Cargo, true)]
    public async Task Create_WithValidViewModel_ReturnsViewResultAsync(string spaceShipName, string companyname, string description, string imageUrl, TransportType transportType, bool expected)
    {
        // Arrange
        var viewModel = new CreateVM { SpaceshipName = spaceShipName, CompanyName = companyname, Description = description, ImageUrl = imageUrl, TransportType = transportType };
        var mockService = new Mock<ISpaceshipsService>();
        var controller = new SpaceshipsController(mockService.Object);

        // Act
        var result = await controller.CreateAsync(viewModel);

        // Assert
        if (expected)
        {
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(SpaceshipsController.IndexAsync).Replace("Async", string.Empty), redirect.ActionName);
            mockService.Verify(s => s.AddAsync(It.Is<SpaceShip>(e =>
                e.SpaceshipName == spaceShipName &&
                e.CompanyName == companyname)), Times.Once);
        }
        else
        {
            var view = Assert.IsType<ViewResult>(result);
            Assert.Null(view.ViewName);
            mockService.Verify(s => s.AddAsync(It.IsAny<SpaceShip>()), Times.Never);
        }
    }

    [Fact]
    public async Task Index_NoParameters_ReturnsViewResultWithCorrectViewModel()
    {
        var mockService = new Mock<ISpaceshipsService>();
        mockService.Setup(service => service.GetAllAsync())
            .Returns(Task.FromResult(new SpaceShip[]
            {
                new SpaceShip { Id = 1, SpaceshipName = "Falcon", CompanyName = "SpaceX", ImageUrl = "url1" },
                new SpaceShip { Id = 2, SpaceshipName = "Enterprise", CompanyName = "Starfleet", ImageUrl = "url2" }
            }));

        var controller = new SpaceshipsController(mockService.Object);

        var result = await controller.IndexAsync();

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<IndexVM>(viewResult.Model);
        mockService.Verify(s => s.GetAllAsync(), Times.Once);
    }

    private static SpaceShip GetMockSpaceship()
    {
        return new SpaceShip
        {
            Id = 1,
            SpaceshipName = "Dragon Cargo",
            CompanyName = "SpaceX",
            Description = "SpaceX's uncrewed spacecraft used to deliver supplies to the ISS.",
            ImageUrl = "/Images/dragon-cargo.jpg",
            TransportType = TransportType.Cargo
        };
    }
}
