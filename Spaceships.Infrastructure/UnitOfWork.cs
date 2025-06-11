using Spaceships.Application.Spaceships;
using Spaceships.Infrastructure.Persistance;

namespace Spaceships.Infrastructure;
public class UnitOfWork(ApplicationContext context,
    ISpaceshipRepository spaceshipRepository) : IUnitOfWork
{
    public ISpaceshipRepository SpaceShips => spaceshipRepository;
    public async Task PersistAllAsync() => await context.SaveChangesAsync();
}
