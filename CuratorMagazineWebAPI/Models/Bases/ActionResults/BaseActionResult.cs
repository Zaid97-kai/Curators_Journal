// ***********************************************************************
// Assembly         : CuratorMagazineWebAPI
// Author           : Zaid
// Created          : 12-21-2022
//
// Last Modified By : Zaid
// Last Modified On : 12-21-2022
// ***********************************************************************
// <copyright file="BaseActionResult.cs" company="CuratorMagazineWebAPI">
//     Zaid97-kai
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shared.Bases;

namespace API.Models.Bases.ActionResults;

/// <summary>
/// Class BaseActionResult.
/// Implements the <see cref="ActionResult" />
/// </summary>
/// <seealso cref="ActionResult" />
public abstract class BaseActionResult : ActionResult
{
    /// <summary>
    /// The error
    /// </summary>
    private readonly string _err;
    /// <summary>
    /// The value
    /// </summary>
    private readonly object _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseActionResult" /> class.
    /// </summary>
    protected BaseActionResult()
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseActionResult" /> class.
    /// </summary>
    /// <param name="err">The error.</param>
    protected BaseActionResult(string err)
    {
        _err = err;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseActionResult" /> class.
    /// </summary>
    /// <param name="value">The value.</param>
    protected BaseActionResult(object value)
    {
        _value = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseActionResult" /> class.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="err">The error.</param>
    protected BaseActionResult(object value, string err)
    {
        _value = value;
        _err = err;
    }
    /// <summary>
    /// Gets the return status code.
    /// </summary>
    /// <value>The return status code.</value>
    protected abstract HttpStatusCode ReturnStatusCode { get; }

    /// <summary>
    /// Gets the error message.
    /// </summary>
    /// <value>The error message.</value>
    protected abstract string ErrorMessage { get; }

    /// <summary>
    /// Execute result as an asynchronous operation.
    /// </summary>
    /// <param name="context">The context in which the result is executed. The context information includes
    /// information about the action that was executed and request information.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    public override async Task ExecuteResultAsync(ActionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)ReturnStatusCode;
        await _write(context);

    }
    /// <summary>
    /// Executes the result operation of the action method synchronously. This method is called by MVC to process
    /// the result of an action method.
    /// </summary>
    /// <param name="context">The context in which the result is executed. The context information includes
    /// information about the action that was executed and request information.</param>
    public override void ExecuteResult(ActionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)ReturnStatusCode;
        Task.Run(async () => await _write(context)).Wait();
    }

    /// <summary>
    /// Writes the specified context.
    /// </summary>
    /// <param name="context">The context.</param>
    private async Task _write(ActionContext context)
    {
        var ret = new BaseResponse<object>(_value);
        if ((_err ?? ErrorMessage) != null)
            ret.Error = $"{_err ?? ErrorMessage}";

        if (ReturnStatusCode != HttpStatusCode.NoContent)//it is not allowed to write in body with HttpStatusCode=NoContent
            await context.HttpContext.Response.WriteAsJsonAsync(ret);
    }
}