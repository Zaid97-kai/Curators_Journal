using Microsoft.EntityFrameworkCore;
using Shared.Entities.Domains;

namespace API.Models.Context;

/// <summary>
/// Interface ICuratorMagazineContext
/// </summary>
public interface ICuratorMagazineContext
{
    #region Entities

    /// <summary>
    /// Gets or sets the users.
    /// </summary>
    /// <value>The users.</value>
    public DbSet<User> Users { get; set; }
    /// <summary>
    /// Gets or sets the divisions.
    /// </summary>
    /// <value>The divisions.</value>
    public DbSet<Division> Divisions { get; set; }
    /// <summary>
    /// Gets or sets the groups.
    /// </summary>
    /// <value>The groups.</value>
    public DbSet<Group> Groups { get; set; }
    /// <summary>
    /// Gets or sets the groups.
    /// </summary>
    /// <value>The groups.</value>
    public DbSet<GroupEvent> GroupEvents { get; set; }
    /// <summary>
    /// Gets or sets the events.
    /// </summary>
    /// <value>The events.</value>
    public DbSet<Event> Events { get; set; }
    /// <summary>
    /// Gets or sets the parents.
    /// </summary>
    /// <value>The parents.</value>
    public DbSet<Parent> Parents { get; set; }
    /// <summary>
    /// Gets or sets the roles.
    /// </summary>
    /// <value>The roles.</value>
    public DbSet<Role> Roles { get; set; }

    #endregion
}