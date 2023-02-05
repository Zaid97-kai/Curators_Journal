using API.Models.Authorization;
using API.Models.Entities.Domains;
using Shared.Bases;
using Shared.Bases.Dtos.BaseHelpers;
using System.Data;
using WebClient.Models.Bases;

namespace WebClient.Data.Services;

/// <summary>
/// Class ApplicationRoleService.
/// Implements the <see cref="BaseService" />
/// </summary>
/// <seealso cref="BaseService" />
public class ApplicationRoleService : BaseService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationRoleService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public ApplicationRoleService(IHttpClientFactory httpClient) : base(httpClient)
    {
    }

    /// <summary>
    /// Get as an asynchronous operation.
    /// </summary>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<List<ApplicationRoleListViewModel>>> GetAsync()
    {
        var dto = await SendAsync<List<ApplicationRoleListViewModel>>("", HttpMethod.Get);
        return dto;
    }

    /// <summary>
    /// Get as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<ApplicationRoleListViewModel>> GetAsync(string id)
    {
        var dto = await SendAsync<ApplicationRoleListViewModel>($"{id}", HttpMethod.Get);
        return dto;
    }

    /// <summary>
    /// Creates the role.
    /// </summary>
    /// <param name="idNum">The identifier number.</param>
    /// <param name="model">The model.</param>
    /// <returns>BaseResponse&lt;ApplicationRoleListViewModel&gt;.</returns>
    public async Task<BaseResponse<ApplicationRoleListViewModel>> CreateRole(string idNum, ApplicationRoleListViewModel model)
    {
        var ret = await SendAsync<ApplicationRoleListViewModel>("CreateRole", HttpMethod.Post, model);
        return ret;
    }

    /// <summary>
    /// Gets the base path.
    /// </summary>
    /// <value>The base path.</value>
    protected override string BasePath => "ApplicationRole";
}