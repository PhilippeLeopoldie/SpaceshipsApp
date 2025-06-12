using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Spaceships.Application.Spaceships;
using Spaceships.Infrastructure;
using Spaceships.Infrastructure.Persistance;
using Spaceships.Infrastructure.Persistance.Repositories;

namespace Terminal;

internal class Program
{
    static SpaceshipsService spaceshipService = null!;
    
    static async Task Main(string[] args)
    {
        string? connectionString;

        var builder = new ConfigurationBuilder();
        builder.AddJsonFile("appsettings.json", false);

        var app = builder.Build();
        connectionString = app.GetConnectionString("DefaultConnection");

        // Configure DbContext options  
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseSqlServer(connectionString)
            .Options;

        // Create and use the context  
        var context = new ApplicationContext(options);
        SpaceshipRepository spaceshipRepository = new SpaceshipRepository(context);
        spaceshipService = new(new UnitOfWork(context, spaceshipRepository));

        await ListAllSpaceshipsAsync();
    }

    private static async Task ListAllSpaceshipsAsync()
    {
        foreach (var item in await spaceshipService.GetAllAsync())
            Console.WriteLine(item.SpaceshipName);

        Console.WriteLine("------------------------------");
    }
}
