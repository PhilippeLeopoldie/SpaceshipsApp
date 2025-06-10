using Spaceships.Domain.Entities;
using Spaceships.Domain.Entities.Enums;

namespace Spaceships.Application.Spaceships;
public class SpaceshipsService(ISpaceshipRepository repository) : ISpaceshipsService
{
    public async Task<SpaceShip[]> GetAllAsync() => await repository.GetAllAsync();

    public async Task<SpaceShip> GetByIdAsync(int id) => await repository.GetByIdAsync(id);

    public async Task AddAsync(SpaceShip spaceship) => await repository.AddAsync(spaceship);
}
