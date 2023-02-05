using API.Models.Authorization;
using Shared.Bases.Dtos.BaseHelpers;
using Shared.Bases;
using WebClient.Models.Bases;
using API.Models.Entities.Domains;

namespace WebClient.Data.Services;

/// <summary>
/// Class AccountService.
/// Implements the <see cref="BaseService" />
/// </summary>
/// <seealso cref="BaseService" />
public class AccountService : BaseService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public AccountService(IHttpClientFactory httpClient) : base(httpClient)
    {
    }

    /// <summary>
    /// Post as an asynchronous operation.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
    public async Task<BaseResponse<LoginViewModel>> PostAsync(LoginViewModel model)
    {
        var ret = await SendAsync<LoginViewModel>($"Login", HttpMethod.Post, model);
        return ret;
    }

    /// <summary>
    /// Gets the base path.
    /// </summary>
    /// <value>The base path.</value>
    protected override string BasePath => "Account";
}