using API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

/// <summary>
/// Class HomeController.
/// Implements the <see cref="Controller" />
/// </summary>
/// <seealso cref="Controller" />
[Authorize]
public class HomeController : Controller
{
    /// <summary>
    /// The user manager
    /// </summary>
    private readonly UserManager<ApplicationUser> _userManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="HomeController"/> class.
    /// </summary>
    /// <param name="userManager">The user manager.</param>
    public HomeController(UserManager<ApplicationUser> userManager)
    {
        this._userManager = userManager;
    }

    /// <summary>
    /// Indexes this instance.
    /// </summary>
    /// <returns>IActionResult.</returns>
    [Authorize(Roles = "User")]
    public IActionResult Index()
    {
        var userName = _userManager.GetUserName(User);
        return View("Index", userName);
    }
}