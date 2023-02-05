using API.Controllers.Bases;
using API.Data;
using API.Models.Authorization;
using API.Models.Bases.ActionResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

/// <summary>
/// Class ApplicationRoleController.
/// Implements the <see cref="BaseController" />
/// </summary>
/// <seealso cref="BaseController" />
public class ApplicationRoleController : BaseController
{
    /// <summary>
    /// The role manager
    /// </summary>
    private readonly RoleManager<ApplicationRole> _roleManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationRoleController" /> class.
    /// </summary>
    /// <param name="roleManager">The role manager.</param>
    public ApplicationRoleController(RoleManager<ApplicationRole> roleManager)
    {
        _roleManager = roleManager;
    }

    /// <summary>
    /// Indexes this instance.
    /// </summary>
    /// <returns>IActionResult.</returns>
    [HttpGet]
    public async Task<BaseResponseActionResult<List<ApplicationRoleListViewModel>>> Index()
    {
        var model = _roleManager.Roles.ToList()
            .Select(r => new ApplicationRoleListViewModel
        {
            RoleName = r.Name,
            Id = r.Id,
            Description = r.Description
        }).ToList();

        return model;
    }

    /// <summary>
    /// Adds the edit application role.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>BaseResponseActionResult&lt;ApplicationRoleListViewModel&gt;.</returns>
    [HttpGet("{id}")]
    public async Task<BaseResponseActionResult<ApplicationRoleListViewModel>> AddEditApplicationRole(string id)
    {
        var model = new ApplicationRoleListViewModel();

        if (!string.IsNullOrEmpty(id))
        {
            var applicationRole = await _roleManager.FindByIdAsync(id);
            if (applicationRole != null)
            {
                model.Id = applicationRole.Id;
                model.RoleName = applicationRole.Name;
                model.Description = applicationRole.Description;
            }
        }

        return model;
    }

    /// <summary>
    /// Adds the edit application role.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="model">The model.</param>
    /// <returns>BaseResponseActionResult&lt;ApplicationRoleListViewModel&gt;.</returns>
    [HttpPost]
    public async Task<BaseResponseActionResult<ApplicationRoleListViewModel>> AddEditApplicationRole(string id, ApplicationRoleListViewModel model)
    {
        if (ModelState.IsValid)
        {
            var isExist = !string.IsNullOrEmpty(id);
            var applicationRole = isExist ? await _roleManager.FindByIdAsync(id) :
                new ApplicationRole
                {
                    CreatedDate = DateTime.UtcNow
                };
            applicationRole.Name = model.RoleName;
            applicationRole.Description = model.Description;
            applicationRole.IPAddress = Request.HttpContext.Connection.RemoteIpAddress?.ToString();

            var roleRuslt = isExist ? await _roleManager.UpdateAsync(applicationRole)
                : await _roleManager.CreateAsync(applicationRole);
        }

        return model;
    }

    /// <summary>
    /// Deletes the application role.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>BaseResponseActionResult&lt;System.String&gt;.</returns>
    [HttpGet("DeleteApplicationRole")]
    public async Task<BaseResponseActionResult<string>> DeleteApplicationRole(string id)
    {
        var name = string.Empty;

        if (!string.IsNullOrEmpty(id))
        {
            var applicationRole = await _roleManager.FindByIdAsync(id);
            if (applicationRole != null)
            {
                name = applicationRole.Name;
            }
        }
        return name;
    }

    /// <summary>
    /// Deletes the application role.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="form">The form.</param>
    /// <returns>BaseResponseActionResult&lt;ApplicationRoleListViewModel&gt;.</returns>
    [HttpDelete]
    public async Task<BaseResponseActionResult<ApplicationRoleListViewModel>> DeleteApplicationRole(string id, FormCollection form)
    {
        if (!string.IsNullOrEmpty(id))
        {
            ApplicationRole applicationRole = await _roleManager.FindByIdAsync(id);
            if (applicationRole != null)
            {
                var roleRuslt = _roleManager.DeleteAsync(applicationRole).Result;
            }
        }
        return Ok();
    }

    //todo: https://social.technet.microsoft.com/wiki/contents/articles/36804.asp-net-core-mvc-authentication-and-role-based-authorization-with-asp-net-core-identity.aspx
}