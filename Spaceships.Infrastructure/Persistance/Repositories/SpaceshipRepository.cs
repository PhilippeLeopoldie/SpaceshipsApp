using Spaceships.Application.Spaceships;
using Spaceships.Domain.Entities;
using Spaceships.Domain.Entities.Enums;

namespace Spaceships.Infrastructure.Persistance.Repositories;
public class SpaceshipRepository : ISpaceshipRepository
{
    public static List<SpaceShip> spaceShips = [
        new SpaceShip
        {
            Id = 1,
            SpaceshipName = "Dragon Cargo",
            Description = "SpaceX's uncrewed spacecraft used to deliver supplies to the ISS.",
            CompanyName = "SpaceX",
            TransportType = TransportType.Cargo,
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/10/SpaceX_CRS-20_Dragon.jpg/640px-SpaceX_CRS-20_Dragon.jpg"
        },
        new SpaceShip
        {
            Id = 2,
            SpaceshipName = "Dragon Crew",
            Description = "SpaceX's reusable capsule for transporting astronauts to the ISS.",
            CompanyName = "SpaceX",
            TransportType = TransportType.Passenger,
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9b/Crew_Dragon_Demo-2_%28NHQ202005300036%29.jpg/640px-Crew_Dragon_Demo-2_%28NHQ202005300036%29.jpg"
        },
        new SpaceShip
        {
            Id = 3,
            SpaceshipName = "Starship",
            Description = "Next-gen fully reusable spacecraft for Mars missions, currently under development.",
            CompanyName = "SpaceX",
            TransportType = TransportType.Cargo,
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0e/Starship_SN9_launch.jpg/640px-Starship_SN9_launch.jpg"
        },
        new SpaceShip
        {
            Id = 4,
            SpaceshipName = "Orion",
            Description = "NASA’s spacecraft for deep-space crewed missions beyond the Moon.",
            CompanyName = "NASA / ESA",
            TransportType = TransportType.Passenger,
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6d/Orion_Capsule_%28Space_Expo%29.jpg/640px-Orion_Capsule_%28Space_Expo%29.jpg"
        },
        new SpaceShip
        {
            Id = 5,
            SpaceshipName = "Soyuz",
            Description = "Russian spacecraft used for crew transport since the 1960s.",
            CompanyName = "Roscosmos",
            TransportType = TransportType.Passenger,
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4d/Soyuz_TMA-16_spacecraft.jpg/640px-Soyuz_TMA-16_spacecraft.jpg"
        },
        new SpaceShip
        {
            Id = 6,
            SpaceshipName = "Progress",
            Description = "Uncrewed cargo spacecraft used to resupply the ISS.",
            CompanyName = "Roscosmos",
            TransportType = TransportType.Cargo,
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f6/Progress_M1-10.jpg/640px-Progress_M1-10.jpg"
        },
        new SpaceShip
        {
            Id = 7,
            SpaceshipName = "Dream Chaser",
            Description = "Spaceplane being developed for cargo delivery to the ISS.",
            CompanyName = "Sierra Space",
            TransportType = TransportType.Cargo,
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3e/Dream_Chaser_mission_illustration.jpg/640px-Dream_Chaser_mission_illustration.jpg"
        }
    ];

    public List<SpaceShip> GetAllAsync()
    {
        return spaceShips;
    }

    public class Context
    {
        public List<SpaceShip> spaceShips { get; set; } = new();
    }
}
