using Microsoft.EntityFrameworkCore;
using Spaceships.Application.Spaceships;
using Spaceships.Domain.Entities;
using Spaceships.Domain.Entities.Enums;
using System.Threading.Tasks;

namespace Spaceships.Infrastructure.Persistance.Repositories;
public class SpaceshipRepository(ApplicationContext context) : ISpaceshipRepository
{
    public async Task AddAsync(SpaceShip spaceShip) => 
        await context.Spaceships.AddAsync(spaceShip);

    public async Task<SpaceShip[]> GetAllAsync() => 
        await context.Spaceships.ToArrayAsync();

    public async Task<SpaceShip?> GetByIdAsync(int id) => 
        await context.Spaceships.FindAsync(id);
}
