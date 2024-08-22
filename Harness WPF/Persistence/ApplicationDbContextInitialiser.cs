using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Harness_WPF.Persistence;

public class ApplicationDbContextInitialiser(
    ILogger<ApplicationDbContextInitialiser> logger,
    ApplicationDbContext context)
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger = logger;
    private readonly ApplicationDbContext _context = context;

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
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
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default Organization
        //if (!await _context.Organizations.AnyAsync())
        //{
        //    await _context.Organizations.AddAsync(new Organization
        //    {
        //        Name = "Demo",
        //        Description = "Demo organization description",
        //        FoundedDate = DateOnly.FromDateTime(DateTime.UtcNow),
        //        ContactEmail = "demoOrg@info.com",
        //        ContactPhone = "+37066699999",
        //        Created = DateTimeOffset.UtcNow,
        //        CreatedBy = "Anonymous",
        //        LastModified = DateTimeOffset.UtcNow,
        //        LastModifiedBy = "Anonymous"
        //    });

        //    await _context.SaveChangesAsync();
        //}

        await _context.SaveChangesAsync();
    }
}