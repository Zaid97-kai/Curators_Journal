// ***********************************************************************
// Assembly         : CuratorMagazineWebAPI
// Author           : Zaid
// Created          : 11-03-2022
//
// Last Modified By : Zaid
// Last Modified On : 12-25-2022
// ***********************************************************************
// <copyright file="PersistenceServiceCollectionExtensions.cs" company="CuratorMagazineWebAPI">
//     Zaid97-kai
// </copyright>
// <summary></summary>
// ***********************************************************************

using CuratorMagazineWebAPI.Data;
using CuratorMagazineWebAPI.Models.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CuratorMagazineWebAPI.DependencyInjection;

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
            //options.UseSqlServer(connectionString);
            options.UseNpgsql(firstConnectionString);
        });
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(secondConnectionString);
        });

        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<ICuratorMagazineContext>(provider => provider.GetService<CuratorMagazineContext>());
        return services;
    }
}