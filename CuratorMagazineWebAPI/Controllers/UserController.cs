// ***********************************************************************
// Assembly         : CuratorMagazineWebAPI
// Author           : Zaid
// Created          : 11-04-2022
//
// Last Modified By : Zaid
// Last Modified On : 12-25-2022
// ***********************************************************************
// <copyright file="UserController.cs" company="CuratorMagazineWebAPI">
//     Zaid97-kai
// </copyright>
// <summary></summary>
// ***********************************************************************
using Shared.Bases.Dtos.BaseHelpers;
using Microsoft.AspNetCore.Mvc;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;
using CuratorMagazineWebAPI.Models.Entities.Domains;
using CuratorMagazineWebAPI.Models.Bases.Filters;
using CuratorMagazineWebAPI.Models.Bases.ActionResults;
using CuratorMagazineWebAPI.Controllers.Bases;

namespace CuratorMagazineWebAPI.Controllers;

/// <summary>
/// Class UserController.
/// Implements the <see cref="Controller" />
/// </summary>
/// <seealso cref="Controller" />
public class UserController : BaseController
{
    /// <summary>
    /// The repository
    /// </summary>
    private readonly IUserRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserController" /> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gets the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>ActionResult&lt;User&gt;.</returns>
    [HttpGet("{id}")]
    public async Task<BaseResponseActionResult<User>> Get(int id)
    {
        var user = await _repository.GetById(id);
        if (user == null)
            return new BaseNotFound();
        
        return user;
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
    /// Posts the specified user.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <returns>ActionResult&lt;User&gt;.</returns>
    [HttpPost("Create")]
    public async Task<BaseResponseActionResult<User>> Post([FromBody] User? user)
    {
        if (user == null)
            return new BaseBadRequest();

        await _repository.Add(user);
        return user;
    }

    /// <summary>
    /// Puts the specified user.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <returns>ActionResult&lt;User&gt;.</returns>
    [HttpPut]
    public async Task<BaseResponseActionResult<User>> Put([FromBody] User? user)
    {
        if (user == null)
        {
            return BadRequest();
        }

        await _repository.Update(user);
        return user;
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>ActionResult&lt;User&gt;.</returns>
    [HttpDelete("{id}")]
    public async Task<BaseResponseActionResult<User>> Delete(int id)
    {
        var user = _repository.Find(x => x.Id == id).Result.FirstOrDefault();

        if (user == null) 
            return NotFound();

        await _repository.Remove(user);
        return user;
    }
}