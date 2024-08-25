using Harness_WPF.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Harness_WPF.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<HarnessDrawing> HarnessDrawings { get; }

        DbSet<HarnessWires> HarnessWires { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
