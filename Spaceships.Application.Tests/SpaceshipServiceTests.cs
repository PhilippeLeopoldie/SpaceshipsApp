using Moq;
using Spaceships.Application.Spaceships;
using Spaceships.Domain.Entities;
using Spaceships.Domain.Entities.Enums;
using Xunit;

namespace Spaceships.Application.Tests;
public class SpaceshipServiceTests()
{
    [Fact]
    public async Task GetCorrectSpaceShipById()
    {
        var mockUoW = new Mock<IUnitOfWork>();
        var service = new SpaceshipsService(mockUoW.Object);
        var spaceship = GetMockSpaceship();
        mockUoW.Setup(x => x.Spaceships.GetByIdAsync(1)).ReturnsAsync(spaceship);

        var result = await service.GetByIdAsync(1);

        Assert.Equal(spaceship, result);
    }

    [Fact]
    public async Task AddSpaceshipAsync()
    {
        var mockRepo = new Mock<ISpaceshipRepository>();
        var mockUoW = new Mock<IUnitOfWork>();
        mockUoW.Setup(x => x.Spaceships).Returns(mockRepo.Object);
        var service = new SpaceshipsService(mockUoW.Object);

        await service.AddAsync(GetMockSpaceship());

        mockUoW.Verify(x => x.Spaceships.AddAsync(It.Is<SpaceShip>(
            x => x.SpaceshipName == "Dragon Cargo")), Times.Once());
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
