using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Spaceships.Domain.Entities;
using Spaceships.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceships.Infrastructure.Persistance;

public class ApplicationContext(DbContextOptions<ApplicationContext> options)
    : IdentityDbContext<ApplicationUser, IdentityRole, string>(options)
{
    public DbSet<SpaceShip> Spaceships { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<SpaceShip>().HasData(
            new SpaceShip
            {
                Id = 1,
                SpaceshipName = "Dragon Cargo",
                Description = "SpaceX's uncrewed spacecraft used to deliver supplies to the ISS.",
                CompanyName = "SpaceX",
                TransportType = TransportType.Cargo,
                ImageUrl = "/Images/dragon-cargo.jpg"
            },
        new SpaceShip
        {
            Id = 2,
            SpaceshipName = "Dragon Crew",
            Description = "SpaceX's reusable capsule for transporting astronauts to the ISS.",
            CompanyName = "SpaceX",
            TransportType = TransportType.Passenger,
            ImageUrl = "/Images/dragon-crew.jpg"
        },
        new SpaceShip
        {
            Id = 3,
            SpaceshipName = "Starship",
            Description = "Next-gen fully reusable spacecraft for Mars missions, currently under development.",
            CompanyName = "SpaceX",
            TransportType = TransportType.Cargo,
            ImageUrl = "/Images/starship.jpg"
        },
        new SpaceShip
        {
            Id = 4,
            SpaceshipName = "Orion",
            Description = "NASA’s spacecraft for deep-space crewed missions beyond the Moon.",
            CompanyName = "NASA / ESA",
            TransportType = TransportType.Passenger,
            ImageUrl = "/Images/orion.jpg"
        },
        new SpaceShip
        {
            Id = 5,
            SpaceshipName = "Soyuz",
            Description = "Russian spacecraft used for crew transport since the 1960s.",
            CompanyName = "Roscosmos",
            TransportType = TransportType.Passenger,
            ImageUrl = "/Images/soyuz.jpg"
        },
        new SpaceShip
        {
            Id = 6,
            SpaceshipName = "Progress",
            Description = "Uncrewed cargo spacecraft used to resupply the ISS.",
            CompanyName = "Roscosmos",
            TransportType = TransportType.Cargo,
            ImageUrl = "/Images/progress.jpg"
        },
        new SpaceShip
        {
            Id = 7,
            SpaceshipName = "Dream Chaser",
            Description = "Spaceplane being developed for cargo delivery to the ISS.",
            CompanyName = "Sierra Space",
            TransportType = TransportType.Cargo,
            ImageUrl = "/Images/dream-chaser.jpg"
        });
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await base.SaveChangesAsync(cancellationToken);
}
