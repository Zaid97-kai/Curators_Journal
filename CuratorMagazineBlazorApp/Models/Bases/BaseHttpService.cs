using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Shared.Bases;

namespace WebClient.Models.Bases;

/// <summary>
/// Class BaseHttpService.
/// </summary>
public abstract class BaseHttpService
{
    /// <summary>
    /// The client
    /// </summary>
    private readonly HttpClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseHttpService" /> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    protected BaseHttpService(HttpClient httpClient)
    {
        _client = httpClient;
        _client.Timeout = TimeSpan.FromMinutes(5);
    }

    /// <summary>
    /// Gets the base path.
    /// </summary>
    /// <value>The base path.</value>
    protected abstract string BasePath { get; }

    /// <summary>
    /// Creates the content.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>HttpContent.</returns>
    private static HttpContent CreateContent(object? model)
    {
        if (model is HttpContent cont)
            return cont;

        var content = new ByteArrayContent(model == null
            ? Array.Empty<byte>()
            : Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model)));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        content.Headers.ContentEncoding.Add("UTF-8");
        return content;
    }

    /// <summary>
    /// Creates the message.
    /// </summary>
    /// <param name="uri">The URI.</param>
    /// <param name="method">The method.</param>
    /// <param name="model">The model.</param>
    /// <returns>HttpRequestMessage.</returns>
    private static HttpRequestMessage CreateMessage(string uri, HttpMethod method, object? model)
    {
        var message = new HttpRequestMessage(method, uri);
        if (method != HttpMethod.Post && method != HttpMethod.Put)
            return message;

        message.Content = CreateContent(model);
        return message;
    }

    /// <summary>
    /// Send as an asynchronous operation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="action">The action.</param>
    /// <param name="method">The method.</param>
    /// <param name="model">The model.</param>
    /// <returns>A Task&lt;OperationResult`1&gt; representing the asynchronous operation.</returns>
    protected async Task<BaseResponse<T>> SendAsync<T>(string action, HttpMethod method, object? model = null)
        where T : class, new()
    {
        try
        {
            var uri = $"{BasePath}/{action}";
            var message = CreateMessage(uri, method, model);
            var response = await _client.SendAsync(message);
            if (response.StatusCode == HttpStatusCode.NoContent)
                return new BaseResponse<T>();

            var content = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<BaseResponse<T>>(content);
            if (res == null)
                return new BaseResponse<T>(new T()) { Error = $"Cant convert response from URI = '{uri}', content returned = '{content}' to type = {typeof(T)} " };
            return res;
        }
        catch (Exception exc)
        {
            return new BaseResponse<T>() { Error = _baseErr(exc) };
        }
    }

    /// <summary>
    /// Bases the error.
    /// </summary>
    /// <param name="exc">The exc.</param>
    /// <returns>System.String.</returns>
    private string _baseErr(Exception exc)
    {
        return $"Message: {exc.Message}, Inner exception: {exc.InnerException?.Message}";
    }
}