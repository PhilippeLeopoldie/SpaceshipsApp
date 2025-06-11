using Spaceships.Domain.Entities.Enums;

namespace Spaceships.Domain.Entities;
public class SpaceShip
{
    public int Id { get; set; }
    public string SpaceshipName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string CompanyName { get; set; } = null!;
    public TransportType TransportType { get; set; }
    public string ImageUrl { get; set; } = null!;
}
