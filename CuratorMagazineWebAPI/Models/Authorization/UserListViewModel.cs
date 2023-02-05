namespace API.Models.Authorization;

/// <summary>
/// Class UserListViewModel.
/// </summary>
public class UserListViewModel
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    /// <value>The email.</value>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the name of the role.
    /// </summary>
    /// <value>The name of the role.</value>
    public string? RoleName { get; set; }
}