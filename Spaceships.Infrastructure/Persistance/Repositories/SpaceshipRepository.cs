using Microsoft.EntityFrameworkCore;
using Spaceships.Application.Spaceships;
using Spaceships.Domain.Entities;
using Spaceships.Domain.Entities.Enums;
using System.Threading.Tasks;

namespace Spaceships.Infrastructure.Persistance.Repositories;
public class SpaceshipRepository(ApplicationContext context) : ISpaceshipRepository
{
    public async Task<SpaceShip[]> GetAllAsync()
    {
        return await context.SpaceShips.ToArrayAsync();
    }

    void ISpaceshipRepository.Create(SpaceShip spaceShip)
    {
        throw new NotImplementedException();
    }

    Task<SpaceShip> ISpaceshipRepository.GetAllAsync()
    {
        throw new NotImplementedException();
    }

    Task<SpaceShip> ISpaceshipRepository.GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
