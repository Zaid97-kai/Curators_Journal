using API.Controllers.Bases;
using API.Models.Bases.ActionResults;
using API.Models.Bases.Filters;
using API.Models.Entities.Domains;
using API.Models.Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Bases.Dtos.BaseHelpers;

namespace API.Controllers;

/// <summary>
/// Class EventController.
/// Implements the <see cref="BaseController" />
/// </summary>
/// <seealso cref="BaseController" />
public class EventController : BaseController
{
    /// <summary>
    /// The repository
    /// </summary>
    private readonly IEventRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="EventController" /> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public EventController(IEventRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gets the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>BaseResponseActionResult&lt;Division&gt;.</returns>
    [HttpGet("{id:int}")]
    public async Task<BaseResponseActionResult<Event>> Get(int id)
    {
        var @event = await _repository.GetById(id);

        if (@event == null)
            return NotFound();

        return @event;
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
    [HttpPost("CreateEvent")]
    public async Task<BaseResponseActionResult<Event>> Create([FromBody] Event? @event)
    {
        if (@event == null)
        {
            return BadRequest();
        }

        await _repository.Add(@event);
        return @event;
    }

    /// <summary>
    /// Puts the specified group events.
    /// </summary>
    /// <param name="groupEvent">The group events.</param>
    /// <returns>BaseResponseActionResult&lt;Division&gt;.</returns>
    [HttpPut("UpdateEvent")]
    public async Task<BaseResponseActionResult<Event>> Put([FromBody] Event? @event)
    {
        if (@event == null)
        {
            return BadRequest();
        }

        await _repository.Update(@event);
        return Ok(@event);
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>BaseResponseActionResult&lt;Division&gt;.</returns>
    [HttpDelete("{id}")]
    public async Task<BaseResponseActionResult<Event>> Delete(int id)
    {
        var @event = _repository.Find(x => x.Id == id).Result.FirstOrDefault();

        if (@event == null)
            return NotFound();

        await _repository.Remove(@event);
        return @event;
    }
}
