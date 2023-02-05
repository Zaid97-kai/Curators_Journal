using API.Data;
using API.Models.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.DependencyInjection;

/// <summary>
/// Class PersistenceServiceCollectionExtensions.
/// </summary>
public static class PersistenceServiceCollectionExtensions
{
    /// <summary>
    /// Adds the persistence.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var firstConnectionString = configuration["ConnectionStrings:DbConnection"];
        var secondConnectionString = configuration["ConnectionStrings:AuthDbConnection"];

        services.AddDbContext<CuratorMagazineContext>(options =>
        {
            options.UseNpgsql(firstConnectionString);
        });
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(secondConnectionString);
        });

        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<ICuratorMagazineContext>(provider => provider.GetService<CuratorMagazineContext>()!);
        return services;
    }
}