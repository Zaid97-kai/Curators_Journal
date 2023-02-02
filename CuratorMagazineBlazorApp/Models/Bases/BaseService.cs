using Shared.Bases;
using Shared.Bases.Dtos.BaseHelpers;
using Shared.Model.Cards.Cards.Dto;

namespace CuratorMagazineBlazorApp.Models.Bases;

/// <summary>
/// Class BaseService.
/// Implements the <see cref="CuratorMagazineBlazorApp.Models.Bases.BaseHttpService" />
/// </summary>
/// <seealso cref="CuratorMagazineBlazorApp.Models.Bases.BaseHttpService" />
public abstract class BaseService : BaseHttpService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    protected BaseService(IHttpClientFactory httpClient) : base(httpClient.CreateClient("CuratorMagazineWebAPI"))
    {
    }
    
    /// <summary>
    /// Posts the asynchronous.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns>Task&lt;BaseResponse&lt;BaseDtoListResult&gt;&gt;.</returns>
    public virtual Task<BaseResponse<BaseDtoListResult>> PostAsync(string query = "")
    {
        return Task.FromResult(new BaseResponse<BaseDtoListResult>());
    }

    /// <summary>
    /// Posts the asynchronous.
    /// </summary>
    /// <param name="card">The card.</param>
    /// <param name="query">The query.</param>
    /// <returns>Task&lt;BaseResponse&lt;BaseDtoListResult&gt;&gt;.</returns>
    public virtual Task<BaseResponse<BaseDtoListResult>> PostAsync(CardDto card, string query = "")
    {
        return Task.FromResult(new BaseResponse<BaseDtoListResult>());
    }

    /// <summary>
    /// Posts the asynchronous.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <param name="parameters">The parameters.</param>
    /// <returns>Task&lt;BaseResponse&lt;BaseDtoListResult&gt;&gt;.</returns>
    public virtual Task<BaseResponse<BaseDtoListResult>> PostAsync(string query, Dictionary<string, string> parameters)
    {
        return Task.FromResult(new BaseResponse<BaseDtoListResult>());
    }

    /// <summary>
    /// Gets the parameters.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <param name="parameters">The parameters.</param>
    /// <returns>Dictionary&lt;System.String, System.String&gt;.</returns>
    public Dictionary<string, string> GetParameters(string query, Dictionary<string, string> parameters)
    {
        if (parameters == null)
            parameters = new Dictionary<string, string>();

        if (!parameters.ContainsKey("query"))
            parameters.Add("query", query);

        if (!parameters.ContainsKey("page"))
            parameters.Add("page", "1");

        return parameters;
    }
}