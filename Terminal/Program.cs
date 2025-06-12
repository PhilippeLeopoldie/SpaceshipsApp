using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Spaceships.Application.Spaceships;
using Spaceships.Infrastructure.Persistance;

namespace Terminal
{
    internal class Program
    {
        static SpaceshipsService spaceshipService = null!;

        static void Main(string[] args)
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

            //employeeService = new(new EmployeeRepository(context));  

            //await ListAllEmployeesAsync();  
            //await ListEmployeeAsync(562);  
        }

        //private static async Task ListAllEmployeesAsync()  
        //{  
        //    foreach (var item in await employeeService.GetAllAsync())  
        //        Console.WriteLine(item.Name);  

        //    Console.WriteLine("------------------------------");  
        //}  
    }
}
