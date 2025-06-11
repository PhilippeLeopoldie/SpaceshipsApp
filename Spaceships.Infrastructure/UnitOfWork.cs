using Spaceships.Application.Spaceships;
using Spaceships.Infrastructure.Persistance;

namespace Spaceships.Infrastructure;
public class UnitOfWork(ApplicationContext context,
    ISpaceshipRepository spaceshipRepository) : IUnitOfWork
{
    public ISpaceshipRepository Spaceships => spaceshipRepository;
    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}
