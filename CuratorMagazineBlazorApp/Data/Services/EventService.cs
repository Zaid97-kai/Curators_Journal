using API.Models.Entities.Domains;
using Shared.Bases;
using Shared.Bases.Dtos.BaseHelpers;
using WebClient.Models.Bases;

namespace WebClient.Data.Services
{
    public class EventService : BaseService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupService"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        public EventService(IHttpClientFactory httpClient) : base(httpClient)
        {
        }

        /// <summary>
        /// Get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
        public async Task<BaseResponse<Event>> GetAsync(int id)
        {
            var dto = await SendAsync<Event>($"{id}", HttpMethod.Get);
            return dto;
        }

        /// <summary>
        /// Create as an asynchronous operation.
        /// </summary>
        /// <param name="group">The Event.</param>
        /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
        public async Task<BaseResponse<Event>> CreateAsync(Event? @event)
        {
            var ret = await SendAsync<Event>($"Create", HttpMethod.Post, @event);
            return ret;
        }

        /// <summary>
        /// Put as an asynchronous operation.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
        public async Task<BaseResponse<Event>> PutAsync(Event? @event)
        {
            var ret = await SendAsync<Event>("", HttpMethod.Put, @event);
            return ret;
        }

        /// <summary>
        /// Delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Task&lt;BaseResponse`1&gt; representing the asynchronous operation.</returns>
        public async Task<BaseResponse<Event>> DeleteAsync(int id)
        {
            var ret = await SendAsync<Event>($"{id}", HttpMethod.Delete);
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
        protected override string BasePath => "Event";
    }
}
