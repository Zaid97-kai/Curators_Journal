namespace WebClient.Shared.Authorization
{
    /// <summary>
    /// Interface ILocalStorageService
    /// </summary>
    public interface ILocalStorageService
    {
        /// <summary>
        /// Sets the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        /// <returns>Task.</returns>
        Task SetAsync<T>(string key, T item) where T : class;

        /// <summary>
        /// Sets the string asynchronous.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>Task.</returns>
        Task SetStringAsync(string key, string value);

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> GetAsync<T>(string key) where T : class;

        /// <summary>
        /// Gets the string asynchronous.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetStringAsync(string key);

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task.</returns>
        Task RemoveAsync(string key);
    }
}
