using API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

/// <summary>
/// Class AccountController.
/// Implements the <see cref="Controller" />
/// </summary>
/// <seealso cref="Controller" />
public class AccountController : Controller
{
    /// <summary>
    /// The sign in manager
    /// </summary>
    private readonly SignInManager<ApplicationUser> _signInManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="AccountController"/> class.
    /// </summary>
    /// <param name="signInManager">The sign in manager.</param>
    public AccountController(SignInManager<ApplicationUser> signInManager)
    {
        this._signInManager = signInManager;
    }
}