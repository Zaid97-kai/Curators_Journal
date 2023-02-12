using Microsoft.JSInterop;
using System.Text.Json;

namespace WebClient.Shared.Authorization
{
    /// <summary>
    /// Class LocalStorageService.
    /// Implements the <see cref="WebClient.Shared.Authorization.ILocalStorageService" />
    /// </summary>
    /// <seealso cref="WebClient.Shared.Authorization.ILocalStorageService" />
    public class LocalStorageService : ILocalStorageService
    {
        /// <summary>
        /// The js runtime
        /// </summary>
        private readonly IJSRuntime _jsRuntime;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalStorageService"/> class.
        /// </summary>
        /// <param name="jsRuntime">The js runtime.</param>
        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        /// <summary>
        /// Set as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task SetAsync<T>(string key, T item) where T : class
        {
            var data = JsonSerializer.Serialize(item);
            await _jsRuntime.InvokeVoidAsync("set", key, data);
        }

        /// <summary>
        /// Sets the string asynchronous.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>Task.</returns>
        public Task SetStringAsync(string key, string value)
        {
            _jsRuntime.InvokeAsync<string>("set", key, value);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Get as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns>A Task&lt;T&gt; representing the asynchronous operation.</returns>
        public async Task<T> GetAsync<T>(string key) where T : class
        {
            var data = await _jsRuntime.InvokeAsync<string>("get", key);
            if (string.IsNullOrEmpty(data))
            {
                return null!;
            }
            return JsonSerializer.Deserialize<T>(data)!;
        }

        /// <summary>
        /// Get string as an asynchronous operation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>A Task&lt;System.String&gt; representing the asynchronous operation.</returns>
        public async Task<string> GetStringAsync(string key)
        {
            return await _jsRuntime.InvokeAsync<string>("get", key);
        }

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task.</returns>
        public Task RemoveAsync(string key)
        {
            _jsRuntime.InvokeAsync<string>("remove", key);
            return Task.CompletedTask;
        }
    }
}
