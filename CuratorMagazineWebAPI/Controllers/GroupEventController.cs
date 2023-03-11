using API.Controllers.Bases;
using API.Models.Bases.ActionResults;
using API.Models.Bases.Filters;
using API.Models.Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Bases.Dtos.BaseHelpers;
using Shared.Entities.Domains;

namespace API.Controllers;

/// <summary>
/// Class GroupEventController.
/// Implements the <see cref="BaseController" />
/// </summary>
/// <seealso cref="BaseController" />
public class GroupEventController : ControllerBase
{
    /// <summary>
    /// The repository
    /// </summary>
    private readonly IGroupEventRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GroupEventController" /> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public GroupEventController(IGroupEventRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gets the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>BaseResponseActionResult&lt;Division&gt;.</returns>
    [HttpGet("{id:int}")]
    public async Task<BaseResponseActionResult<GroupEvent>> Get(int id)
    {
        var groupEvent = await _repository.GetById(id);

        if (groupEvent == null)
            return NotFound();

        return groupEvent;
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
    /// Posts the specified group events.
    /// </summary>
    /// <param name="groupEvent">The group events.</param>
    /// <returns>BaseResponseActionResult&lt;Division&gt;.</returns>
    [HttpPost("CreateGroupEvent")]
    public async Task<BaseResponseActionResult<GroupEvent>> Create([FromBody] GroupEvent? groupEvent)
    {
        if (groupEvent == null)
        {
            return BadRequest();
        }

        await _repository.Add(groupEvent);
        return groupEvent;
    }

    /// <summary>
    /// Puts the specified group events.
    /// </summary>
    /// <param name="groupEvent">The group events.</param>
    /// <returns>BaseResponseActionResult&lt;Division&gt;.</returns>
    [HttpPut("UpdateGroupEvent")]
    public async Task<BaseResponseActionResult<GroupEvent>> Put([FromBody] GroupEvent? groupEvent)
    {
        if (groupEvent == null)
        {
            return BadRequest();
        }

        await _repository.Update(groupEvent);
        return Ok(groupEvent);
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>BaseResponseActionResult&lt;Division&gt;.</returns>
    [HttpDelete("{id}")]
    public async Task<BaseResponseActionResult<GroupEvent>> Delete(int id)
    {
        var groupEvent = _repository.Find(x => x.Id == id).Result.FirstOrDefault();

        if (groupEvent == null)
            return NotFound();

        await _repository.Remove(groupEvent);
        return groupEvent;
    }
}
