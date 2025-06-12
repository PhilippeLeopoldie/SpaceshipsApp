using Spaceships.Domain.Entities.Enums;

namespace Spaceships.Web.Views.Spaceship;

public class DetailsVM
{
    public required string SpaceshipName { get; set; }
    public required string Description { get; set; }
    public required string CompanyName { get; set; }
    public required TransportType TransportType { get; set; }
    public required string ImageUrl { get; set; }
}
