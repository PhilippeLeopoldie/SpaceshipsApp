
using Microsoft.EntityFrameworkCore;

namespace Spaceships.Infrastructure.Persistance;
public class ApplicationContext : DbContext
{
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var modifiedEntries = ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Modified);


        return await base.SaveChangesAsync(cancellationToken);
    }
}
