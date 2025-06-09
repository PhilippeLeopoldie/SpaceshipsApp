
namespace Spaceships.Application.Spaceships;
public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
