using Harness_WPF.Domain.Common;
using Harness_WPF.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Harness_WPF.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<HarnessDrawing> HarnessDrawings { get; set; }
        public DbSet<HarnessWires> HarnessWires { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configure the HarnessDrawing table
            builder.Entity<HarnessDrawing>(entity =>
            {
                entity.ToTable("Harness_drawing");

                entity.Property(e => e.Id)
                      .HasColumnName("ID");

                entity.Property(e => e.Harness)
                      .HasColumnName("Harness")
                      .HasMaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT);

                entity.Property(e => e.HarnessVersion)
                      .HasColumnName("Harness_version")
                      .HasMaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT);

                entity.Property(e => e.Drawing)
                      .HasColumnName("Drawing")
                      .HasMaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT);

                entity.Property(e => e.DrawingVersion)
                      .HasColumnName("Drawing_version")
                      .HasMaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT);

                entity.HasIndex(e => e.Id).HasDatabaseName("IX_Harness_drawing_ID");
            });

            // Configure the HarnessWires table
            builder.Entity<HarnessWires>(entity =>
            {
                entity.ToTable("Harness_wires");

                entity.Property(e => e.Id)
                      .HasColumnName("ID");

                entity.Property(e => e.HarnessID)
                      .HasColumnName("Harness_ID")
                      .IsRequired();

                entity.Property(e => e.Length)
                      .HasColumnName("Length")
                      .HasMaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT);

                entity.Property(e => e.Color)
                      .HasColumnName("Color")
                      .HasMaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT);

                entity.Property(e => e.Housing1)
                      .HasColumnName("Housing_1")
                      .HasMaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT);

                entity.Property(e => e.Housing2)
                      .HasColumnName("Housing_2")
                      .HasMaxLength(EntityConstants.DEFAULT_VARCHAR_LENGHT);

                entity.HasIndex(e => e.Id).HasDatabaseName("IX_Harness_wires_ID");
            });

            base.OnModelCreating(builder);
        }
    }
}