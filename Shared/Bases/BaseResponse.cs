namespace Shared.Bases;

/// <summary>
/// Class BaseResponse.
/// </summary>
/// <typeparam name="T"></typeparam>
public class BaseResponse<T>
{
    /// <summary>
    /// If error is null or empty
    /// </summary>
    /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
    public bool Success => (Error ?? "") == string.Empty;

    /// <summary>
    /// Error message
    /// </summary>
    /// <value>The error.</value>
    public string Error { get; set; }

    /// <summary>
    /// Response result
    /// </summary>
    /// <value>The result.</value>
    public T Result { get; set; }

    /// <summary>
    /// Empty constructor
    /// </summary>
    public BaseResponse()
    {

    }

    /// <summary>
    /// Data constructor
    /// </summary>
    /// <param name="data">The data.</param>
    public BaseResponse(T data)
    {
        Result = data;
    }
}