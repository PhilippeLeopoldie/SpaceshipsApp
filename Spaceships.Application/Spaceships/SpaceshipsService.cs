using Spaceships.Domain.Entities;

namespace Spaceships.Application.Spaceships;
public class SpaceshipsService(IUnitOfWork unitOfWork) : ISpaceshipsService
{
    public async Task<SpaceShip[]> GetAllAsync() => await unitOfWork.Spaceships.GetAllAsync();

    public async Task<SpaceShip?> GetByIdAsync(int id) => await unitOfWork.Spaceships.GetByIdAsync(id);

    public async Task AddAsync(SpaceShip spaceship)
    {
        await unitOfWork.Spaceships.AddAsync(spaceship);
        await unitOfWork.PersistAllAsync();
    }
}
