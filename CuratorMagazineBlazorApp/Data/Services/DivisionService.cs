using CuratorMagazineWebAPI.Models.Entities.Domains;
using Shared.Bases;
using Shared.Bases.Dtos.BaseHelpers;
using WebClient.Models.Bases;

namespace WebClient.Data.Services;

/// <summary>
/// Class DivisionService.
/// Implements the <see cref="BaseService" />
/// </summary>
/// <seealso cref="BaseService" />
public class DivisionService : BaseService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DivisionService" /> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public DivisionService(IHttpClientFactory httpClient) : base(httpClient)
    {
    }

    /// <summary>
    /// Get as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<Division>> GetAsync(int id)
    {
        var dto = await SendAsync<Division>($"{id}", HttpMethod.Get);
        return dto;
    }

    /// <summary>
    /// Create as an asynchronous operation.
    /// </summary>
    /// <param name="division">The Division.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<Division>> CreateAsync(Division division)
    {
        var ret = await SendAsync<Division>($"Create", HttpMethod.Post, division);
        return ret;
    }

    /// <summary>
    /// Put as an asynchronous operation.
    /// </summary>
    /// <param name="division">The Division.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<Division>> PutAsync(Division division)
    {
        var ret = await SendAsync<Division>("", HttpMethod.Put, division);
        return ret;
    }

    /// <summary>
    /// Delete as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<Division>> DeleteAsync(int id)
    {
        var ret = await SendAsync<Division>($"{id}", HttpMethod.Delete);
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
    protected override string BasePath => "Division";
}