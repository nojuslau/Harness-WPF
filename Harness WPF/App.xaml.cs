using Harness_WPF.Domain.Entities;
using Harness_WPF.Domain.ViewModels;
using Harness_WPF.Persistence;
using Harness_WPF.Repositories;
using Harness_WPF.Services;
using Harness_WPF.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;

namespace Harness_WPF
{
    public partial class App : Application
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;
        private readonly IConfiguration _configuration;
        private Repository repository;
        public IServiceProvider serviceProvider { get; private set; }
        public bool enableSeeding = true;

        public App()
        {
            _configuration = BuildConfiguration();
            _dbContextOptions = BuildDbContextOptions(_configuration);
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();

            // Database context
            using var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var dbInitializer = new ApplicationDbContextInitialiser(context);
            await dbInitializer.InitialiseAsync();

            // Seeds first data into database
            if (enableSeeding)
            {
                await dbInitializer.SeedAsync();
            }
            else
            {
                await dbInitializer.DeSeedAsync();
            }

            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();

            // Register the ApplicationDbContext with dependency injection
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            // Register IRepository and Repository
            services.AddTransient<IRepository, Repository>();

            // Register services generically
            services.AddTransient(typeof(IService<>), typeof(Service<>));

            // Register ViewModels
            services.AddTransient<HarnessDrawingVM>();
            services.AddTransient<HarnessWiresVM>();
        }

        // App constructor configurations
        private IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        private DbContextOptions<ApplicationDbContext> BuildDbContextOptions(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            enableSeeding = Convert.ToBoolean(configuration.GetSection("DatabaseSettings:EnableSeeding").Value);

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' is missing or empty.");
            }

            optionsBuilder.UseSqlServer(connectionString);

            return optionsBuilder.Options;
        }
    }
}
