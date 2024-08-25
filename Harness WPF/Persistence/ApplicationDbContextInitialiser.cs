using Harness_WPF.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Harness_WPF.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while initializing the database.", ex);
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while seeding the database.", ex);
        }
    }

    public async Task DeSeedAsync()
    {
        try
        {
            await TryDeSeedAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while seeding the database.", ex);
        }
    }

    private async Task TrySeedAsync()
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            if (!await _context._harnessDrawings.AnyAsync())
            {
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Harness_drawing ON");
                await _context._harnessDrawings.AddRangeAsync(
                    new HarnessDrawing { Id = 40953, Harness = "S2563532M", HarnessVersion = "S-6", Drawing = "EP", DrawingVersion = "S-4" },
                    new HarnessDrawing { Id = 40442, Harness = "S2563545M", HarnessVersion = "S12", Drawing = "EP", DrawingVersion = "S-4" },
                    new HarnessDrawing { Id = 39087, Harness = "S2563549M", HarnessVersion = "S-9", Drawing = "EP", DrawingVersion = "S-4" },
                    new HarnessDrawing { Id = 39077, Harness = "S2641137M", HarnessVersion = "S-9", Drawing = "EP", DrawingVersion = "S-4" },
                    new HarnessDrawing { Id = 38643, Harness = "S2656843M", HarnessVersion = "5", Drawing = "EP", DrawingVersion = "S-4" }
                );
                await _context.SaveChangesAsync();
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Harness_drawing OFF");
            }

            if (!await _context._harnessWires.AnyAsync())
            {
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Harness_wires ON");
                await _context._harnessWires.AddRangeAsync(
                    new HarnessWires { Id = 3115654, HarnessID = 38643, Length = "950", Color = "R", Housing1 = "C604:19", Housing2 = "P2.BX2:1" },
                    new HarnessWires { Id = 3115655, HarnessID = 38643, Length = "450", Color = "R", Housing1 = "C604:23", Housing2 = "C521:1" },
                    new HarnessWires { Id = 3158749, HarnessID = 39077, Length = "665", Color = "BN", Housing1 = "E71.B:1", Housing2 = "C604:21" },
                    new HarnessWires { Id = 3158750, HarnessID = 39077, Length = "665", Color = "GR", Housing1 = "E71.B:4", Housing2 = "C604:23" },
                    new HarnessWires { Id = 3159894, HarnessID = 39087, Length = "465", Color = "W", Housing1 = "E71.A:1", Housing2 = "C681" },
                    new HarnessWires { Id = 3159895, HarnessID = 39087, Length = "680", Color = "SB", Housing1 = "E71.P:3", Housing2 = "G504-2" },
                    new HarnessWires { Id = 3277678, HarnessID = 40442, Length = "475", Color = "GN", Housing1 = "P2.E85:1", Housing2 = "C680" },
                    new HarnessWires { Id = 3277679, HarnessID = 40442, Length = "980", Color = "R", Housing1 = "P2.BX2:1", Housing2 = "E30.P:1" },
                    new HarnessWires { Id = 3328453, HarnessID = 40953, Length = "365", Color = "W", Housing1 = "C621:6", Housing2 = "C681" },
                    new HarnessWires { Id = 3328454, HarnessID = 40953, Length = "305", Color = "SB", Housing1 = "C620:24", Housing2 = "G508-3" }
                );
                await _context.SaveChangesAsync();
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Harness_wires OFF");
            }

            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new InvalidOperationException("An error occurred while seeding the database.", ex);
        }
    }

    private async Task TryDeSeedAsync()
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            if (!await _context._harnessDrawings.AnyAsync())
            {
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Harness_drawing ON");
                var drawingsToRemove = new List<HarnessDrawing>
                {
                    new HarnessDrawing { Id = 40953, Harness = "S2563532M", HarnessVersion = "S-6", Drawing = "EP", DrawingVersion = "S-4" },
                    new HarnessDrawing { Id = 40442, Harness = "S2563545M", HarnessVersion = "S12", Drawing = "EP", DrawingVersion = "S-4" },
                    new HarnessDrawing { Id = 39087, Harness = "S2563549M", HarnessVersion = "S-9", Drawing = "EP", DrawingVersion = "S-4" },
                    new HarnessDrawing { Id = 39077, Harness = "S2641137M", HarnessVersion = "S-9", Drawing = "EP", DrawingVersion = "S-4" },
                    new HarnessDrawing { Id = 38643, Harness = "S2656843M", HarnessVersion = "5", Drawing = "EP", DrawingVersion = "S-4" }
                };

                _context._harnessDrawings.AttachRange(drawingsToRemove);
                _context._harnessDrawings.RemoveRange(drawingsToRemove);

                await _context.SaveChangesAsync();
            }

            if (!await _context._harnessWires.AnyAsync())
            {
                var wiresToRemove = new List<HarnessWires>
                {
                    new HarnessWires { Id = 3115654, HarnessID = 38643, Length = "950", Color = "R", Housing1 = "C604:19", Housing2 = "P2.BX2:1" },
                    new HarnessWires { Id = 3115655, HarnessID = 38643, Length = "450", Color = "R", Housing1 = "C604:23", Housing2 = "C521:1" },
                    new HarnessWires { Id = 3158749, HarnessID = 39077, Length = "665", Color = "BN", Housing1 = "E71.B:1", Housing2 = "C604:21" },
                    new HarnessWires { Id = 3158750, HarnessID = 39077, Length = "665", Color = "GR", Housing1 = "E71.B:4", Housing2 = "C604:23" },
                    new HarnessWires { Id = 3159894, HarnessID = 39087, Length = "465", Color = "W", Housing1 = "E71.A:1", Housing2 = "C681" },
                    new HarnessWires { Id = 3159895, HarnessID = 39087, Length = "680", Color = "SB", Housing1 = "E71.P:3", Housing2 = "G504-2" },
                    new HarnessWires { Id = 3277678, HarnessID = 40442, Length = "475", Color = "GN", Housing1 = "P2.E85:1", Housing2 = "C680" },
                    new HarnessWires { Id = 3277679, HarnessID = 40442, Length = "980", Color = "R", Housing1 = "P2.BX2:1", Housing2 = "E30.P:1" },
                    new HarnessWires { Id = 3328453, HarnessID = 40953, Length = "365", Color = "W", Housing1 = "C621:6", Housing2 = "C681" },
                    new HarnessWires { Id = 3328454, HarnessID = 40953, Length = "305", Color = "SB", Housing1 = "C620:24", Housing2 = "G508-3" }
                };

                _context._harnessWires.AttachRange(wiresToRemove);
                _context._harnessWires.RemoveRange(wiresToRemove);
                await _context.SaveChangesAsync();
            }

            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new InvalidOperationException("An error occurred while deseeding the database.", ex);
        }
    }
}