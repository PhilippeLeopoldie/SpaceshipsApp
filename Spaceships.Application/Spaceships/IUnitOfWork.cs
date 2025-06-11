
namespace Spaceships.Application.Spaceships;
public interface IUnitOfWork
{
    Task PersistAllAsync();
    ISpaceshipRepository Spaceships { get; }
}
