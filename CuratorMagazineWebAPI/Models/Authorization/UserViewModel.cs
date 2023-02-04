using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CuratorMagazineWebAPI.Models.Authorization;

/// <summary>
/// Class UserViewModel.
/// </summary>
public class UserViewModel
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the user.
    /// </summary>
    /// <value>The name of the user.</value>
    public string? UserName { get; set; }

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    /// <value>The password.</value>
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    /// <summary>
    /// Gets or sets the confirm password.
    /// </summary>
    /// <value>The confirm password.</value>
    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    public string? ConfirmPassword { get; set; }

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
    /// Gets or sets the application roles.
    /// </summary>
    /// <value>The application roles.</value>
    public List<SelectListItem>? ApplicationRoles { get; set; }

    /// <summary>
    /// Gets or sets the application role identifier.
    /// </summary>
    /// <value>The application role identifier.</value>
    [Display(Name = "Role")]
    public string? ApplicationRoleId { get; set; }
}

/// <summary>
/// Class EditUserViewModel.
/// </summary>
public class EditUserViewModel
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
    /// Gets or sets the application roles.
    /// </summary>
    /// <value>The application roles.</value>
    public List<SelectListItem>? ApplicationRoles { get; set; }

    /// <summary>
    /// Gets or sets the application role identifier.
    /// </summary>
    /// <value>The application role identifier.</value>
    [Display(Name = "Role")]
    public string? ApplicationRoleId { get; set; }
}