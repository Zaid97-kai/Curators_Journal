using System.Net;

namespace API.Models.Bases.ActionResults;

/// <summary>
/// Class BaseBadRequest.
/// Implements the <see cref="BaseActionResult" />
/// </summary>
/// <seealso cref="BaseActionResult" />
public class BaseBadRequest : BaseActionResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseBadRequest" /> class.
    /// </summary>
    public BaseBadRequest() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseBadRequest" /> class.
    /// </summary>
    /// <param name="err">The error.</param>
    public BaseBadRequest(string err)
        : base(err) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseBadRequest" /> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public BaseBadRequest(object value)
        : base(value) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseBadRequest" /> class.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="err">The error.</param>
    public BaseBadRequest(object value, string err)
        : base(value, err) { }

    /// <summary>
    /// Gets the return status code.
    /// </summary>
    /// <value>The return status code.</value>
    protected override HttpStatusCode ReturnStatusCode => HttpStatusCode.BadRequest;

    /// <summary>
    /// Gets the error message.
    /// </summary>
    /// <value>The error message.</value>
    protected override string ErrorMessage => "Bad request occured";
}