using API.Data;
using API.Models.Authorization;
using API.Models.Bases.ActionResults;
using Microsoft.AspNetCore.Authorization;
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
    /// Initializes a new instance of the <see cref="AccountController" /> class.
    /// </summary>
    /// <param name="signInManager">The sign in manager.</param>
    public AccountController(SignInManager<ApplicationUser> signInManager)
    {
        this._signInManager = signInManager;
    }

    /// <summary>
    /// Logins the specified return URL.
    /// </summary>
    /// <param name="returnUrl">The return URL.</param>
    /// <returns>OkResult.</returns>
    [HttpGet]
    public async Task<OkResult> Login(string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return Ok();
    }

    /// <summary>
    /// Logins the specified model.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="returnUrl">The return URL.</param>
    /// <returns>BaseResponseActionResult&lt;LoginViewModel&gt;.</returns>
    [HttpPost("Login")]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<BaseResponseActionResult<LoginViewModel>> Login(LoginViewModel model, string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return model;
            }
        }
        return model;
    }

    /// <summary>
    /// Redirects to local.
    /// </summary>
    /// <param name="returnUrl">The return URL.</param>
    /// <returns>IActionResult.</returns>
    private IActionResult RedirectToLocal(string returnUrl)
    {
        if (Url.IsLocalUrl(returnUrl))
        {
            return Redirect(returnUrl);
        }
        else
        {
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}