using Spaceships.Domain.Entities.Enums;

namespace Spaceships.Web.Views.Spaceship;

public class DetailsVM
{
    public required string SpaceshipName { get; set; } = null!;
    public required string Description { get; set; } = null!;
    public required string CompanyName { get; set; } = null!;
    public required TransportType TransportType { get; set; }
    public required string ImageUrl { get; set; } = null!;
}
