using Spaceships.Domain.Entities.Enums;

namespace Spaceships.Web.Views.Spaceship;

public class IndexVM
{
    public SpaceshipVM[] SpaceshipVMs { get; set; } = null!;

    public class SpaceshipVM
    {
        public required int Id { get; set; }
        public required string SpaceshipName { get; set; } = null!;
        //public required string Description { get; set; } = null!;
        public required string CompanyName { get; set; } = null!;
        //public required TransportType TransportType { get; set; }
        public required string ImageUrl { get; set; } = null!;
    }
}
