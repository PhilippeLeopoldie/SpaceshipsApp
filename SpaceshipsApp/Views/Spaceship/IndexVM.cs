using Spaceships.Domain.Entities.Enums;

namespace Spaceships.Web.Views.Spaceship;

public class IndexVM
{
    public SpaceshipVM[]? SpaceshipVMs { get; set; }

    public class SpaceshipVM
    {
        public required int Id { get; set; }
        public required string SpaceshipName { get; set; }
        public required string CompanyName { get; set; }
        public required string ImageUrl { get; set; }
    }
}
