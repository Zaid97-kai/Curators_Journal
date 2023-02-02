// ***********************************************************************
// Assembly         : CuratorMagazineWebAPI
// Author           : Zaid
// Created          : 12-21-2022
//
// Last Modified By : Zaid
// Last Modified On : 12-21-2022
// ***********************************************************************
// <copyright file="BaseNotFound.cs" company="CuratorMagazineWebAPI">
//     Zaid97-kai
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Net;

namespace CuratorMagazineWebAPI.Models.Bases.ActionResults;

/// <summary>
/// Class BaseNotFound.
/// Implements the <see cref="CuratorMagazineWebAPI.Models.Bases.ActionResults.BaseActionResult" />
/// </summary>
/// <seealso cref="CuratorMagazineWebAPI.Models.Bases.ActionResults.BaseActionResult" />
public class BaseNotFound : BaseActionResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseNotFound" /> class.
    /// </summary>
    public BaseNotFound() { }
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseNotFound" /> class.
    /// </summary>
    /// <param name="err">The error.</param>
    public BaseNotFound(string err)
        : base(err) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseNotFound" /> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public BaseNotFound(object value)
        : base(value) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseNotFound" /> class.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="err">The error.</param>
    public BaseNotFound(object value, string err)
        : base(value, err) { }

    /// <summary>
    /// Gets the return status code.
    /// </summary>
    /// <value>The return status code.</value>
    protected override HttpStatusCode ReturnStatusCode => HttpStatusCode.NotFound;
    /// <summary>
    /// Gets the error message.
    /// </summary>
    /// <value>The error message.</value>
    protected override string ErrorMessage => "Объект или вызываемый метод не найден.";
}