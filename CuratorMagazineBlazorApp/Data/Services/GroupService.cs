using CuratorMagazineBlazorApp.Models.Bases;
using CuratorMagazineWebAPI.Models.Entities.Domains;
using Shared.Bases.Dtos.BaseHelpers;
using Shared.Bases;

namespace CuratorMagazineBlazorApp.Data.Services;

/// <summary>
/// Class GroupService.
/// Implements the <see cref="BaseService" />
/// </summary>
/// <seealso cref="BaseService" />
public class GroupService : BaseService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GroupService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public GroupService(IHttpClientFactory httpClient) : base(httpClient)
    {
    }

    /// <summary>
    /// Get as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<Group>> GetAsync(int id)
    {
        var dto = await SendAsync<Group>($"{id}", HttpMethod.Get);
        return dto;
    }

    public async Task<BaseResponse<User?>> GetGroupCuratorAsync(int id)
    {
        BaseResponse<User?> dto = await SendAsync<User>($"GetGroupCurator/{id}", HttpMethod.Post);
        return dto;
    }

    /// <summary>
    /// Create as an asynchronous operation.
    /// </summary>
    /// <param name="group">The group.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<Group>> CreateAsync(Group group)
    {
        var ret = await SendAsync<Group>($"Create", HttpMethod.Post, group);
        return ret;
    }

    /// <summary>
    /// Put as an asynchronous operation.
    /// </summary>
    /// <param name="group">The group.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<Group>> PutAsync(Group group)
    {
        var ret = await SendAsync<Group>("", HttpMethod.Put, group);
        return ret;
    }

    /// <summary>
    /// Delete as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<Group>> DeleteAsync(int id)
    {
        var ret = await SendAsync<Group>($"{id}", HttpMethod.Delete);
        return ret;
    }

    /// <summary>
    /// Post as an asynchronous operation.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public override async Task<BaseResponse<BaseDtoListResult>> PostAsync(string query = "")
    {
        var parameters = new Dictionary<string, string>
        {
            { "query", query },
            { "page", "1" }
        };
        var ret = await SendAsync<BaseDtoListResult>("GetList", HttpMethod.Post, parameters);
        return ret;
    }

    /// <summary>
    /// Gets the base path.
    /// </summary>
    /// <value>The base path.</value>
    protected override string BasePath => "Group";
}