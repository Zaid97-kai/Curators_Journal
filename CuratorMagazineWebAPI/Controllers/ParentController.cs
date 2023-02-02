// ***********************************************************************
// Assembly         : CuratorMagazineWebAPI
// Author           : Zaid
// Created          : 11-04-2022
//
// Last Modified By : Zaid
// Last Modified On : 12-25-2022
// ***********************************************************************
// <copyright file="ParentController.cs" company="CuratorMagazineWebAPI">
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
/// Class ParentController.
/// Implements the <see cref="Controller" />
/// </summary>
/// <seealso cref="Controller" />
public class ParentController : BaseController
{
    /// <summary>
    /// The repository
    /// </summary>
    private readonly IParentRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ParentController" /> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public ParentController(IParentRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gets the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>BaseResponseActionResult&lt;Parent&gt;.</returns>
    [HttpGet("{id}")]
    public async Task<BaseResponseActionResult<Parent>> Get(int id)
    {
        var parent = await _repository.GetById(id);

        if (parent == null)
            return NotFound();

        return parent;
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
    /// Posts the specified parent.
    /// </summary>
    /// <param name="parent">The parent.</param>
    /// <returns>BaseResponseActionResult&lt;Parent&gt;.</returns>
    [HttpPost]
    public async Task<BaseResponseActionResult<Parent>> Post(Parent? parent)
    {
        if (parent == null)
            return new BaseBadRequest();

        await _repository.Add(parent);
        return parent;
    }

    /// <summary>
    /// Puts the specified parent.
    /// </summary>
    /// <param name="parent">The parent.</param>
    /// <returns>BaseResponseActionResult&lt;Parent&gt;.</returns>
    [HttpPut]
    public async Task<BaseResponseActionResult<Parent>> Put(Parent? parent)
    {
        if (parent == null)
        {
            return BadRequest();
        }

        await _repository.Update(parent);
        return parent;
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>BaseResponseActionResult&lt;Parent&gt;.</returns>
    [HttpDelete("{id}")]
    public async Task<BaseResponseActionResult<Parent>> Delete(int id)
    {
        var parent = _repository.Find(x => x.Id == id).Result.FirstOrDefault();

        if (parent == null)
            return NotFound();

        await _repository.Remove(parent);
        return parent;
    }
}