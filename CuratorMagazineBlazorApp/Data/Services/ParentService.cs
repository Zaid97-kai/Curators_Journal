using API.Models.Entities.Domains;
using Shared.Bases;
using Shared.Bases.Dtos.BaseHelpers;
using WebClient.Models.Bases;

namespace WebClient.Data.Services;

/// <summary>
/// Class ParentService.
/// Implements the <see cref="BaseService" />
/// </summary>
/// <seealso cref="BaseService" />
public class ParentService : BaseService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ParentService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public ParentService(IHttpClientFactory httpClient) : base(httpClient)
    {
    }

    /// <summary>
    /// Get as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<Parent>> GetAsync(int id)
    {
        var dto = await SendAsync<Parent>($"{id}", HttpMethod.Get);
        return dto;
    }

    /// <summary>
    /// Create as an asynchronous operation.
    /// </summary>
    /// <param name="parent">The Parent.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<Parent>> CreateAsync(Parent? parent)
    {
        var ret = await SendAsync<Parent>($"Create", HttpMethod.Post, parent);
        return ret;
    }

    /// <summary>
    /// Put as an asynchronous operation.
    /// </summary>
    /// <param name="parent">The Parent.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<Parent>> PutAsync(Parent? parent)
    {
        var ret = await SendAsync<Parent>("", HttpMethod.Put, parent);
        return ret;
    }

    /// <summary>
    /// Delete as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<Parent>> DeleteAsync(int id)
    {
        var ret = await SendAsync<Parent>($"{id}", HttpMethod.Delete);
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
    protected override string BasePath => "Parent";
}