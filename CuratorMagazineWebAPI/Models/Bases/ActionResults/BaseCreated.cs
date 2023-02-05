using System.Net;

namespace API.Models.Bases.ActionResults;

/// <summary>
/// Class BaseCreated.
/// Implements the <see cref="BaseActionResult" />
/// </summary>
/// <seealso cref="BaseActionResult" />
public class BaseCreated : BaseActionResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseCreated" /> class.
    /// </summary>
    public BaseCreated() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseCreated" /> class.
    /// </summary>
    /// <param name="err">The error.</param>
    public BaseCreated(string err)
        : base(err) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseCreated" /> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public BaseCreated(object value)
        : base(value) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseCreated" /> class.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="err">The error.</param>
    public BaseCreated(object value, string err)
        : base(value, err) { }

    /// <summary>
    /// Gets the return status code.
    /// </summary>
    /// <value>The return status code.</value>
    protected override HttpStatusCode ReturnStatusCode => HttpStatusCode.Created;

    /// <summary>
    /// Gets the error message.
    /// </summary>
    /// <value>The error message.</value>
    protected override string ErrorMessage => null;
}
