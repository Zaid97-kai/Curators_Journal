using API.Controllers.Bases;
using API.Models.Bases.ActionResults;
using API.Models.Bases.Filters;
using API.Models.Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Bases.Dtos.BaseHelpers;
using Shared.Entities.Domains;

namespace API.Controllers;

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

    /// <summary>
    /// The user repository
    /// </summary>
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GroupController" /> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="userRepository">The user repository.</param>
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
    [HttpGet("{id:int}")]
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

    /// <summary>
    /// Gets the group curator.
    /// </summary>
    /// <param name="groupId">The group identifier.</param>
    /// <returns>BaseResponseActionResult&lt;BaseDtoListResult&gt;.</returns>
    [HttpPost("GetGroupCurator")]
    public async Task<BaseResponseActionResult<BaseDtoListResult>> GetGroupCurator(int groupId)
    {
        var ret = await _userRepository.GetList(new BaseFilterGetList()
        {
            query = "",
            page = 1,
            groupId = groupId
        });

        return ret;
    }

    /// <summary>
    /// Posts the specified group.
    /// </summary>
    /// <param name="group">The group.</param>
    /// <returns>BaseResponseActionResult&lt;Group&gt;.</returns>
    [HttpPost("Create")]
    public async Task<BaseResponseActionResult<Group>> CreateGroup([FromBody] Group? group)
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
    public async Task<BaseResponseActionResult<Group>> Put([FromBody] Group? group)
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