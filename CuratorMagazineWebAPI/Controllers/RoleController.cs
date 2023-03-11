using API.Controllers.Bases;
using API.Models.Bases.ActionResults;
using API.Models.Bases.Filters;
using API.Models.Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Bases.Dtos.BaseHelpers;
using Shared.Entities.Domains;

namespace API.Controllers;

/// <summary>
/// Class RoleController.
/// Implements the <see cref="BaseController" />
/// </summary>
/// <seealso cref="BaseController" />
public class RoleController : BaseController
{
    /// <summary>
    /// The repository
    /// </summary>
    private readonly IRoleRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="RoleController" /> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public RoleController(IRoleRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gets the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>BaseResponseActionResult&lt;Role&gt;.</returns>
    [HttpGet("{id}")]
    public async Task<BaseResponseActionResult<Role>> Get(int id)
    {
        var role = await _repository.GetById(id);
        if (role == null)
            return new BaseNotFound();

        return role;
    }

    /// <summary>
    /// Gets the list.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns>BaseResponseActionResult&lt;BaseDtoListResult&gt;.</returns>
    [HttpPost("GetList")]
    public async Task<BaseResponseActionResult<BaseDtoListResult>> GetList([FromBody] BaseFilterGetList data)
    {
        var ret = await _repository.GetList(data);
        return ret;
    }

    /// <summary>
    /// Posts the specified role.
    /// </summary>
    /// <param name="role">The role.</param>
    /// <returns>BaseResponseActionResult&lt;Role&gt;.</returns>
    [HttpPost]
    public async Task<BaseResponseActionResult<Role>> Post([FromBody] Role? role)
    {
        if (role == null)
            return new BaseBadRequest();

        await _repository.Add(role);
        return role;
    }

    /// <summary>
    /// Puts the specified role.
    /// </summary>
    /// <param name="role">The role.</param>
    /// <returns>BaseResponseActionResult&lt;Role&gt;.</returns>
    [HttpPut]
    public async Task<BaseResponseActionResult<Role>> Put(Role? role)
    {
        if (role == null)
        {
            return BadRequest();
        }

        await _repository.Update(role);
        return role;
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>BaseResponseActionResult&lt;Role&gt;.</returns>
    [HttpDelete("{id}")]
    public async Task<BaseResponseActionResult<Role>> Delete(int id)
    {
        var role = _repository.Find(x => x.Id == id).Result.FirstOrDefault();

        if (role == null) 
            return NotFound();

        await _repository.Remove(role);
        return role;
    }
}