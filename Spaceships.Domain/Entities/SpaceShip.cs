using Spaceships.Domain.Entities.Enums;

namespace Spaceships.Domain.Entities;
public class SpaceShip
{
    public int Id { get; set; }
    public string SpaceshipName { get; set; }
    public string Description { get; set; }
    public string CompanyName { get; set; }
    public TransportType TransportType { get; }
    public string ImageUrl { get; set; }
}
