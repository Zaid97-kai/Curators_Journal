using Shared.Bases;
using Shared.Bases.Dtos.BaseHelpers;
using Shared.Entities.Domains;
using WebClient.Models.Bases;

namespace WebClient.Data.Services;

/// <summary>
/// Class RoleService.
/// Implements the <see cref="BaseService" />
/// </summary>
/// <seealso cref="BaseService" />
public class RoleService : BaseService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoleService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public RoleService(IHttpClientFactory httpClient) : base(httpClient)
    {
    }

    /// <summary>
    /// Get as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<Role>> GetAsync(int id)
    {
        var dto = await SendAsync<Role>($"{id}", HttpMethod.Get);
        return dto;
    }

    /// <summary>
    /// Create as an asynchronous operation.
    /// </summary>
    /// <param name="role">The Role.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<Role>> CreateAsync(Role? role)
    {
        var ret = await SendAsync<Role>($"Create", HttpMethod.Post, role);
        return ret;
    }

    /// <summary>
    /// Put as an asynchronous operation.
    /// </summary>
    /// <param name="role">The Role.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<Role>> PutAsync(Role? role)
    {
        var ret = await SendAsync<Role>("", HttpMethod.Put, role);
        return ret;
    }

    /// <summary>
    /// Delete as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<Role>> DeleteAsync(int id)
    {
        var ret = await SendAsync<Role>($"{id}", HttpMethod.Delete);
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
    protected override string BasePath => "Role";
}