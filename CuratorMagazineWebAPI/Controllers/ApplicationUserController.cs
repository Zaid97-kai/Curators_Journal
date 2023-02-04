using CuratorMagazineWebAPI.Data;
using CuratorMagazineWebAPI.Models.Authorization;
using CuratorMagazineWebAPI.Models.Bases.ActionResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CuratorMagazineWebAPI.Controllers;

/// <summary>
/// Class ApplicationUserController.
/// Implements the <see cref="Controller" />
/// </summary>
/// <seealso cref="Controller" />
public class ApplicationUserController : Controller
{
    /// <summary>
    /// The user manager
    /// </summary>
    private readonly UserManager<ApplicationUser> _userManager;

    /// <summary>
    /// The role manager
    /// </summary>
    private readonly RoleManager<ApplicationRole> _roleManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationUserController" /> class.
    /// </summary>
    /// <param name="userManager">The user manager.</param>
    /// <param name="roleManager">The role manager.</param>
    public ApplicationUserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    /// <summary>
    /// Indexes this instance.
    /// </summary>
    /// <returns>Task&lt;BaseResponseActionResult&lt;List&lt;UserListViewModel&gt;&gt;&gt;.</returns>
    [HttpGet]
    public async Task<BaseResponseActionResult<List<UserListViewModel>>> Index()
    {
        var model = new List<UserListViewModel>();

        model = _userManager.Users.Select(u => new UserListViewModel
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email
        }).ToList();

        return model;
    }

    /// <summary>
    /// Adds the user.
    /// </summary>
    /// <returns>BaseResponseActionResult&lt;UserViewModel&gt;.</returns>
    [HttpGet("AddUser")]
    public async Task<BaseResponseActionResult<UserViewModel>> AddUser()
    {
        var model = new UserViewModel();

        model.ApplicationRoles = _roleManager.Roles.Select(r => new SelectListItem
        {
            Text = r.Name,
            Value = r.Id
        }).ToList();

        return model;
    }

    /// <summary>
    /// Adds the user.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>BaseResponseActionResult&lt;UserViewModel&gt;.</returns>
    [HttpPost("AddUser")]
    public async Task<BaseResponseActionResult<UserViewModel>> AddUser([FromBody] UserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser
            {
                Name = model.Name,
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var applicationRole = await _roleManager.FindByIdAsync(model.ApplicationRoleId);
                if (applicationRole != null)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, applicationRole.Name);
                    if (roleResult.Succeeded)
                    {
                        return Ok();
                    }
                }
            }
        }
        return model;
    }

    /// <summary>
    /// Edits the user.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>BaseResponseActionResult&lt;EditUserViewModel&gt;.</returns>
    [HttpGet("EditUser")]
    public async Task<BaseResponseActionResult<EditUserViewModel>> EditUser(string id)
    {
        var model = new EditUserViewModel
        {
            ApplicationRoles = _roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList()
        };

        if (!string.IsNullOrEmpty(id))
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                model.Name = user.Name;
                model.Email = user.Email;
                model.ApplicationRoleId = _roleManager.Roles.Single(r => r.Name == _userManager.GetRolesAsync(user).Result.Single()).Id;
            }
        }

        return model;
    }

    /// <summary>
    /// Edits the user.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="model">The model.</param>
    /// <returns>BaseResponseActionResult&lt;EditUserViewModel&gt;.</returns>
    [HttpPut("EditUser")]
    public async Task<BaseResponseActionResult<EditUserViewModel>> EditUser(string id, EditUserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Name = model.Name;
                user.Email = model.Email;
                var existingRole = _userManager.GetRolesAsync(user).Result.Single();
                var existingRoleId = _roleManager.Roles.Single(r => r.Name == existingRole).Id;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    if (existingRoleId != model.ApplicationRoleId)
                    {
                        var roleResult = await _userManager.RemoveFromRoleAsync(user, existingRole);
                        if (roleResult.Succeeded)
                        {
                            var applicationRole = await _roleManager.FindByIdAsync(model.ApplicationRoleId);
                            if (applicationRole != null)
                            {
                                var newRoleResult = await _userManager.AddToRoleAsync(user, applicationRole.Name);
                                if (newRoleResult.Succeeded)
                                {
                                    return Ok();
                                }
                            }
                        }
                    }
                }
            }
        }
        return model;
    }

    /// <summary>
    /// Deletes the user.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>BaseResponseActionResult&lt;System.String&gt;.</returns>
    [HttpGet("DeleteUser")]
    public async Task<BaseResponseActionResult<string>> DeleteUser(string id)
    {
        var name = string.Empty;
        if (!string.IsNullOrEmpty(id))
        {
            var applicationUser = await _userManager.FindByIdAsync(id);
            if (applicationUser != null)
            {
                name = applicationUser.Name;
            }
        }
        return name;
    }

    /// <summary>
    /// Deletes the user.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="form">The form.</param>
    /// <returns>OkResult.</returns>
    [HttpDelete("DeleteUser")]
    public async Task<OkResult> DeleteUser(string id, FormCollection form)
    {
        if (!string.IsNullOrEmpty(id))
        {
            var applicationUser = await _userManager.FindByIdAsync(id);
            if (applicationUser != null)
            {
                var result = await _userManager.DeleteAsync(applicationUser);
                if (result.Succeeded)
                {
                    return Ok();
                }
            }
        }
        return Ok();
    }
}