using CuratorMagazineBlazorApp.Models.Bases;
using CuratorMagazineWebAPI.Models.Entities.Domains;
using Shared.Bases.Dtos.BaseHelpers;
using Shared.Bases;

namespace CuratorMagazineBlazorApp.Data.Services;

/// <summary>
/// Class UserService.
/// Implements the <see cref="BaseService" />
/// </summary>
/// <seealso cref="BaseService" />
public class UserService : BaseService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserService" /> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public UserService(IHttpClientFactory httpClient) : base(httpClient)
    {
    }

    /// <summary>
    /// Get as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<User>> GetAsync(int id)
    {
        var dto = await SendAsync<User>($"{id}", HttpMethod.Get);
        return dto;
    }

    /// <summary>
    /// Create as an asynchronous operation.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<User>> CreateAsync(User user)
    {
        var ret = await SendAsync<User>($"Create", HttpMethod.Post, user);
        return ret;
    }

    /// <summary>
    /// Put as an asynchronous operation.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<User>> PutAsync(User user)
    {
        var ret = await SendAsync<User>("", HttpMethod.Put, user);
        return ret;
    }

    /// <summary>
    /// Delete as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<User>> DeleteAsync(int id)
    {
        var ret = await SendAsync<User>($"{id}", HttpMethod.Delete);
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
            { "page", "1" },
            { "groupId", null }
        };
        var ret = await SendAsync<BaseDtoListResult>("GetList", HttpMethod.Post, parameters);
        return ret;
    }

    /// <summary>
    /// Gets the base path.
    /// </summary>
    /// <value>The base path.</value>
    protected override string BasePath => "User";
}