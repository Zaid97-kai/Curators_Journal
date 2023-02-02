using System.Security.Cryptography;
using System.Text;

namespace CuratorMagazineBlazorApp.Data.Common;

/// <summary>
/// Class OperationResult.
/// </summary>
[Serializable]
public abstract class OperationResult
{
    /// <summary>
    /// The logs
    /// </summary>
    private readonly IList<string> _logs = (IList<string>)new List<string>();

    /// <summary>
    /// Initializes a new instance of the <see cref="OperationResult"/> class.
    /// </summary>
    protected OperationResult() => this.ActivityId = OperationResult.Generate(11);

    /// <summary>
    /// Gets or sets the activity identifier.
    /// </summary>
    /// <value>The activity identifier.</value>
    public string ActivityId { get; set; }

    /// <summary>
    /// Gets or sets the metadata.
    /// </summary>
    /// <value>The metadata.</value>
    public Metadata Metadata { get; set; }

    /// <summary>
    /// Gets or sets the exception.
    /// </summary>
    /// <value>The exception.</value>
    public Exception Exception { get; set; }

    /// <summary>
    /// Gets the logs.
    /// </summary>
    /// <value>The logs.</value>
    public IEnumerable<string> Logs => (IEnumerable<string>)this._logs;

    /// <summary>
    /// Creates the result.
    /// </summary>
    /// <typeparam name="TResult">The type of the t result.</typeparam>
    /// <param name="result">The result.</param>
    /// <param name="error">The error.</param>
    /// <returns>OperationResult&lt;TResult&gt;.</returns>
    public static OperationResult<TResult> CreateResult<TResult>(TResult result, Exception error)
    {
        return new OperationResult<TResult>()
        {
            Result = result
        };
    }

    /// <summary>
    /// Creates the result.
    /// </summary>
    /// <typeparam name="TResult">The type of the t result.</typeparam>
    /// <param name="result">The result.</param>
    /// <returns>OperationResult&lt;TResult&gt;.</returns>
    public static OperationResult<TResult> CreateResult<TResult>(TResult result) => OperationResult.CreateResult<TResult>(result, (Exception)null);

    /// <summary>
    /// Creates the result.
    /// </summary>
    /// <typeparam name="TResult">The type of the t result.</typeparam>
    /// <returns>OperationResult&lt;TResult&gt;.</returns>
    public static OperationResult<TResult> CreateResult<TResult>() => OperationResult.CreateResult<TResult>(default(TResult), (Exception)null);

    /// <summary>
    /// Appends the log.
    /// </summary>
    /// <param name="messageLog">The message log.</param>
    public void AppendLog(string messageLog)
    {
        if (string.IsNullOrEmpty(messageLog))
            return;
        if (messageLog.Length > 500)
            this._logs.Add(messageLog.Substring(0, 500) ?? "");
        this._logs.Add(messageLog);
    }

    /// <summary>
    /// Appends the log.
    /// </summary>
    /// <param name="messageLogs">The message logs.</param>
    public void AppendLog(IEnumerable<string> messageLogs)
    {
        if (messageLogs == null)
            return;
        foreach (string messageLog in messageLogs)
            this.AppendLog(messageLog);
    }

    /// <summary>
    /// Generates the specified size.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <returns>System.String.</returns>
    private static string Generate(int size)
    {
        var charArray = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        var data = new byte[1];
        using (var cryptoServiceProvider = new RNGCryptoServiceProvider())
        {
            cryptoServiceProvider.GetNonZeroBytes(data);
            data = new byte[size];
            cryptoServiceProvider.GetNonZeroBytes(data);
        }
        var stringBuilder = new StringBuilder(size);
        foreach (var num in data)
            stringBuilder.Append(charArray[(int)num % charArray.Length]);
        return stringBuilder.ToString();
    }
}

/// <summary>
/// Class OperationResult.
/// Implements the <see cref="CuratorMagazineBlazorApp.Data.Common.OperationResult" />
/// </summary>
/// <typeparam name="T"></typeparam>
/// <seealso cref="CuratorMagazineBlazorApp.Data.Common.OperationResult" />
[Serializable]
public class OperationResult<T> : OperationResult
{
    /// <summary>
    /// Gets or sets the result.
    /// </summary>
    /// <value>The result.</value>
    public T Result { get; set; }

    /// <summary>
    /// Gets a value indicating whether this <see cref="OperationResult{T}"/> is ok.
    /// </summary>
    /// <value><c>true</c> if ok; otherwise, <c>false</c>.</value>
    public bool Ok
    {
        get
        {
            if (this.Metadata == null)
                return this.Exception == null && (object)this.Result != null;
            if (this.Exception != null || (object)this.Result == null)
                return false;
            Metadata metadata = this.Metadata;
            return metadata == null || metadata.Type != MetadataType.Error;
        }
    }
}