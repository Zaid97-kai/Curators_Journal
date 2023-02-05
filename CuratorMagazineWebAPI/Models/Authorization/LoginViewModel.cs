using System.ComponentModel.DataAnnotations;

namespace API.Models.Authorization;

/// <summary>
/// Class LoginViewModel.
/// </summary>
public class LoginViewModel
{
    /// <summary>
    /// Gets or sets the name of the user.
    /// </summary>
    /// <value>The name of the user.</value>
    [Required]
    public string? UserName { get; set; }

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    /// <value>The password.</value>
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [remember me].
    /// </summary>
    /// <value><c>true</c> if [remember me]; otherwise, <c>false</c>.</value>
    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}