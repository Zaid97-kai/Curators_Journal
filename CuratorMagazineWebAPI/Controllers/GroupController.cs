// ***********************************************************************
// Assembly         : CuratorMagazineWebAPI
// Author           : Zaid
// Created          : 11-04-2022
//
// Last Modified By : Zaid
// Last Modified On : 12-25-2022
// ***********************************************************************
// <copyright file="GroupController.cs" company="CuratorMagazineWebAPI">
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
/// Class GroupController.
/// Implements the <see cref="BaseController" />
/// </summary>
/// <seealso cref="BaseController" />
public class GroupController : BaseController
{
    /// <summary>
    /// The unit of work
    /// </summary>
    private readonly IGroupRepository _repository;

    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GroupController" /> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public GroupController(IGroupRepository repository, IUserRepository userRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
    }

    /// <summary>
    /// Gets the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>BaseResponseActionResult&lt;Group&gt;.</returns>
    [HttpGet("{id}")]
    public async Task<BaseResponseActionResult<Group>> Get(int id)
    {
        var group = await _repository.GetById(id);

        if (group == null)
            return NotFound();

        return group;
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

    [HttpPost("GetGroupCurator")]
    public async Task<BaseResponseActionResult<BaseDtoListResult>> GetGroupCurator(int groupId)
    {
        var ret = await _userRepository.GetList(new BaseFilterGetList()
            { page = 1, query = "", groupId = groupId });

        return ret;
    }

    /// <summary>
    /// Posts the specified group.
    /// </summary>
    /// <param name="group">The group.</param>
    /// <returns>BaseResponseActionResult&lt;Group&gt;.</returns>
    [HttpPost]
    public async Task<BaseResponseActionResult<Group>> Post(Group? group)
    {
        if (group == null)
        {
            return BadRequest();
        }

        await _repository.Add(group);
        return group;
    }

    /// <summary>
    /// Puts the specified group.
    /// </summary>
    /// <param name="group">The group.</param>
    /// <returns>BaseResponseActionResult&lt;Group&gt;.</returns>
    [HttpPut]
    public async Task<BaseResponseActionResult<Group>> Put(Group? group)
    {
        if (group == null)
        {
            return BadRequest();
        }

        await _repository.Update(group);
        return group;
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>BaseResponseActionResult&lt;Group&gt;.</returns>
    [HttpDelete("{id}")]
    public async Task<BaseResponseActionResult<Group>> Delete(int id)
    {
        var group = _repository.Find(x => x.Id == id).Result.FirstOrDefault();

        if (group == null)
            return NotFound();

        await _repository.Remove(group);
        return group;
    }
}