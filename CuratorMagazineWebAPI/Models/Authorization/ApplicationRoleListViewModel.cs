namespace API.Models.Authorization;

/// <summary>
/// Class ApplicationRoleListViewModel.
/// </summary>
public class ApplicationRoleListViewModel
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the role.
    /// </summary>
    /// <value>The name of the role.</value>
    public string? RoleName { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>The description.</value>
    public string? Description { get; set; }
}