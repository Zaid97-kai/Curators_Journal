// ***********************************************************************
// Assembly         : CuratorMagazineWebAPI
// Author           : Zaid
// Created          : 11-04-2022
//
// Last Modified By : Zaid
// Last Modified On : 12-26-2022
// ***********************************************************************
// <copyright file="DivisionController.cs" company="CuratorMagazineWebAPI">
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
/// Class DivisionController.
/// Implements the <see cref="BaseController" />
/// </summary>
/// <seealso cref="BaseController" />
public class DivisionController : BaseController
{
    /// <summary>
    /// The repository
    /// </summary>
    private readonly IDivisionRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DivisionController" /> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public DivisionController(IDivisionRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gets the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>BaseResponseActionResult&lt;Division&gt;.</returns>
    [HttpGet("{id}")]
    public async Task<BaseResponseActionResult<Division>> Get(int id)
    {
        var division = await _repository.GetById(id);

        if (division == null)
            return NotFound();

        //_mqService.SendMessage(division);

        return division;
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
    /// Posts the specified division.
    /// </summary>
    /// <param name="division">The division.</param>
    /// <returns>BaseResponseActionResult&lt;Division&gt;.</returns>
    [HttpPost]
    public async Task<BaseResponseActionResult<Division>> Post(Division? division)
    {
        if (division == null)
        {
            return BadRequest();
        }

        await _repository.Add(division);
        return division;
    }

    /// <summary>
    /// Puts the specified division.
    /// </summary>
    /// <param name="division">The division.</param>
    /// <returns>BaseResponseActionResult&lt;Division&gt;.</returns>
    [HttpPut]
    public async Task<BaseResponseActionResult<Division>> Put([FromBody] Division? division)
    {
        if (division == null)
        {
            return BadRequest();
        }
        
        await _repository.Update(division);
        return Ok(division);
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>BaseResponseActionResult&lt;Division&gt;.</returns>
    [HttpDelete("{id}")]
    public async Task<BaseResponseActionResult<Division>> Delete(int id)
    {
        var division = _repository.Find(x => x.Id == id).Result.FirstOrDefault();

        if (division == null) 
            return NotFound();

        await _repository.Remove(division);
        return division;
    }
}