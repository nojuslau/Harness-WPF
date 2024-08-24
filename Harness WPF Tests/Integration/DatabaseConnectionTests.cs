using Harness_WPF.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Harness_WPF_Tests.Integration;
public class DatabaseConnectionTests
{
    private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

    public DatabaseConnectionTests()
    {
        var configuration = BuildConfiguration();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(connectionString)
            .Options;
    }

    private IConfiguration BuildConfiguration()
    {
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        return configurationBuilder.Build();
    }

    [Fact]
    public async Task CanConnectToDatabase()
    {
        // Arrange
        await using var context = new ApplicationDbContext(_dbContextOptions);
        var canConnect = false;

        // Act
        try
        {
            // Test if the database can be connected to
            await context.Database.OpenConnectionAsync();
            await context.Database.CloseConnectionAsync();
            canConnect = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception occurred: {ex.Message}");
        }

        //Assert
        Assert.True(canConnect, "Failed to connect to the database.");
    }
}