using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TvShowsManager.Cli;
using TvShowsManager.DataContext;
using TvShowsManager.Data.Interfaces;
using TvShowsManager.Services.Interfaces;
using TvShowsManager.Data.Implementations;
using TvShowsManager.Services.Services;
using TvShowsManager.Services.Utils;
using System;

class Program
{
    static void Main(string[] args)
    {
        MainAsync(args).Wait();
    }

    static async Task MainAsync(string[] args)
    {
        //Here we add the appsettings to have a global configuration file
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        IConfigurationRoot configuration = builder.Build();

        //We configure our service provider and application services
        var serviceProvider = new ServiceCollection()
            .AddDbContext<TvShowContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            )
            .AddAutoMapper(typeof(AutoMapperProfile))
            .AddScoped<IShowService, ShowService>()
            .AddScoped<IShowData, ShowData>()
            .BuildServiceProvider();

        //We connect to our context so we can initialize our database for first use
        using var context = serviceProvider.GetService<TvShowContext>();
        if (context == null)
        {
            Console.WriteLine("Could not create DbContext.");
            return;
        }

        //Here we call the initializer to create the database, tables and seed initial data
        DbInitializer.Initialize(context);

        var menuManager = new MenuManager(serviceProvider.GetRequiredService<IShowService>());
        await menuManager.ShowMenu();
    }
}