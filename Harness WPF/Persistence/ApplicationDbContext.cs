using Harness_WPF.Domain.Common;
using Harness_WPF.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Harness_WPF.Persistence;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<HarnessDrawing> harnessDrawings { get; set; }
    public DbSet<HarnessWires> harnessWires { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<HarnessDrawing>()
            .Property(m => m.HarnessVersion)
            .HasMaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT);
        builder.Entity<HarnessDrawing>()
            .Property(m => m.DrawingVersion)
            .HasMaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT);
        builder.Entity<HarnessDrawing>()
            .Property(m => m.Harness)
            .HasMaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT);
        builder.Entity<HarnessDrawing>()
            .Property(m => m.Drawing)
            .HasMaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT);
        builder.Entity<HarnessDrawing>().HasIndex(x => x.Id);

        builder.Entity<HarnessWires>()
            .Property(m => m.HarnessID)
            .IsRequired();
        builder.Entity<HarnessWires>()
            .Property(m => m.Housing1)
            .HasMaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT);
        builder.Entity<HarnessWires>()
            .Property(m => m.Housing2)
            .HasMaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT);
        builder.Entity<HarnessWires>()
            .Property(m => m.Color)
            .HasMaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT);
        builder.Entity<HarnessWires>().HasIndex(x => x.Id);

        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(builder);
    }
}
