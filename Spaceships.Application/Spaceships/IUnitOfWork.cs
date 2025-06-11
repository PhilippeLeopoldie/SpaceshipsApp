
namespace Spaceships.Application.Spaceships;
public interface IUnitOfWork
{
    ISpaceshipRepository Spaceships { get; }
    Task PersistAllAsync();
}
