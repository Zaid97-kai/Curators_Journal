using API.Models.Authorization;
using API.Models.Entities.Domains;
using API.Models.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

/// <summary>
/// Class ApplicationDbContext.
/// Implements the <see cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext{CuratorMagazineWebAPI.Data.ApplicationUser, CuratorMagazineWebAPI.Data.ApplicationRole, System.String}" />
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext{CuratorMagazineWebAPI.Data.ApplicationUser, CuratorMagazineWebAPI.Data.ApplicationRole, System.String}" />
public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationDbContext" /> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    /// <summary>
    /// Override this method to further configure the model that was discovered by convention from the entity types
    /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
    /// and re-used for subsequent instances of your derived context.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
    /// define extension methods on this object that allow you to configure aspects of the model that are specific
    /// to a given database.</param>
    /// <remarks><para>
    /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
    /// then this method will not be run.
    /// </para>
    /// <para>
    /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information.
    /// </para></remarks>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Roles

        var administratorRole = new ApplicationRole()
        {
            Id = "1",
            Name = "Administrator",
            Description = "Administrator"
        };

        var deputyDirectorRole = new ApplicationRole()
        {
            Id = "2",
            Name = "Deputy Director",
            Description = "Deputy Director" 
        };

        var curatorRole = new ApplicationRole()
        {
            Id = "3",
            Name = "Curator",
            Description = "Curator"
        };

        #endregion

        #region Users

        var adminUser = new ApplicationUser()
        {
            UserName = "admin",
            PasswordHash = ""
        };

        adminUser.PasswordHash = (new PasswordHasher<ApplicationUser>()).HashPassword(adminUser, "123");

        var deputyDirectorUser = new ApplicationUser()
        {
            UserName = "deputyDirector",
            PasswordHash = ""
        };

        deputyDirectorUser.PasswordHash = (new PasswordHasher<ApplicationUser>()).HashPassword(deputyDirectorUser, "123");

        var curatorUser = new ApplicationUser()
        {
            UserName = "curator",
            PasswordHash = ""
        };

        curatorUser.PasswordHash = (new PasswordHasher<ApplicationUser>()).HashPassword(curatorUser, "123");

        #endregion

        modelBuilder.Entity<ApplicationRole>().HasData(administratorRole, deputyDirectorRole, curatorRole);

        base.OnModelCreating(modelBuilder);
    }
}