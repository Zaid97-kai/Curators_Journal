using Microsoft.AspNetCore.Identity;

namespace API.Data;

/// <summary>
/// Class ApplicationUser.
/// Implements the <see cref="IdentityUser" />
/// </summary>
/// <seealso cref="IdentityUser" />
public class ApplicationUser : IdentityUser
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string? Name { get; set; }
}