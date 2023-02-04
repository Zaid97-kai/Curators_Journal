using Microsoft.AspNetCore.Identity;

namespace CuratorMagazineWebAPI.Data;

/// <summary>
/// Class ApplicationRole.
/// Implements the <see cref="IdentityRole" />
/// </summary>
/// <seealso cref="IdentityRole" />
public class ApplicationRole : IdentityRole
{
    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>The description.</value>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the created date.
    /// </summary>
    /// <value>The created date.</value>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets the ip address.
    /// </summary>
    /// <value>The ip address.</value>
    public string? IPAddress { get; set; }
}